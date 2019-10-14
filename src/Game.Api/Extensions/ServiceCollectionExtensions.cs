using AutoMapper;
using Game.Api.Infrastructure.Queries;
using Game.Domain.Entities.PlayerAgrgegate;
using Game.Infraestructura;
using Game.Infraestructura.Repositories;
using Game.Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
            public static IServiceCollection AddCustomMvc(this IServiceCollection services)
            {
                // Add framework services.
                services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                                  //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services
                                                  //services.AddControllers();
                return services;
            }

            public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddDbContext<GameContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName: "GameDB");
                }, ServiceLifetime.Scoped);

                return services;
            }

            public static IServiceCollection AddSwagger(this IServiceCollection services)
            {
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Game HTTP API",
                        Version = "v1"
                    });

                });

                return services;
            }

            public static IServiceCollection AddRepositories(this IServiceCollection services)
            {
                services.AddScoped<IPlayerRepository, PlayerRepository>();

                return services;
            }

            public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            {
                services.AddScoped<IPlayerService, PlayerService>();

                return services;
            }

            public static IServiceCollection AddCustomAutomapper(this IServiceCollection services)
            {
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                return services;
            }

            public static IServiceCollection AddQueries(this IServiceCollection services)
            {
                services.AddScoped<IPlayerQuery, PlayerQuery>();

                return services;
            }
    }
}
