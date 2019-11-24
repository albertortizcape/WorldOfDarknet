using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Game.Api.Application.Queries.Player;
using Game.Api.Application.Validations;
using Game.Api.Infrastructure.Authentication;
using Game.Api.Infrastructure.Services;
using Game.Domain.Entities.UserAggregate;
using Game.Domain.Entities.PlayerAgrgegate;
using Game.Infraestructura.Repositories;
using Game.Infraestructura.Services;
using Game.Infrastructure.Providers;
using Game.Infrastructure.Repositories;
using Game.Infrastructure.Services;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddControllersAsServices()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterUserCommandValidator>());

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

        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment environment) =>
           services
               .AddProblemDetails(configure =>
               {
                   configure.IncludeExceptionDetails = _ => environment.EnvironmentName == "Development";
               });

        public static IServiceCollection AddCustomApiBehaviour(this IServiceCollection services)
        {

            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
                options.SuppressInferBindingSourcesForParameters = false;

                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Type = $"https://httpstatuses.com/400",
                        Detail = "Please refer to the errors property for additional details."
                    };
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes =
                         {
                                "application/problem+json",
                                "application/problem+xml"
                         }
                    };
                };
            });
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("Authentication");
            services.Configure<AuthenticationSettings>(appSettingsSection);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICypherProvider, CypherProvider>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Key"])),
                };
            });

            return services;
        }
    }
}
