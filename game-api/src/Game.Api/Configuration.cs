﻿using Game.Api.Infrastructure.SignalR;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Api
{
    public static class Configuration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            services.AddSignalR();

            return services
                    .AddSwagger()
                    .AddCustomAutomapper()
                    .AddCustomMvc()
                    .AddCustomProblemDetails(environment)
                    .AddRepositories()
                    .AddQueries()
                    .AddApplicationServices()
                    .AddCustomAuthentication(configuration);
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
        {
            return app.AddSwaggerConfigure()
                .UseHttpsRedirection()
                .UseProblemDetails()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();

                    endpoints.MapHub<GameHub>("/hub/game");
                });
        }
    }
}
