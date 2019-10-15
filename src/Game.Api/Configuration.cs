using System;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Api
{
    public static class Configuration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment environment)
        {
            return services
                    .AddSwagger()
                    .AddCustomAutomapper()
                    .AddCustomMvc()
                    .AddCustomProblemDetails(environment)
                    .AddRepositories()
                    .AddQueries()
                    .AddApplicationServices();
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
        {
            return app.AddSwaggerConfigure()
                .UseHttpsRedirection()
                .UseProblemDetails()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
