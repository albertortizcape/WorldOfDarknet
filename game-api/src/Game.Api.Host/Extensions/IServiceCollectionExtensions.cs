using System;
using Game.Infraestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Api.Host.Extensions
{
    public static class IServiceCollectionExtensions
    { 
        public static IServiceCollection AddInMemoryProviderDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "GameDB");
            }, ServiceLifetime.Scoped);

            return services;
        }

        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameContext>(options =>
            {
                var server = "localhost";
                var port = "5432";
                var name = "worldofdb";
                var user = "postgres";
                var password = "123456";
                options.UseNpgsql($"Host={server};Port={port};Database={name};Username={user};Password={password}");
            }, ServiceLifetime.Scoped);

            return services;
        }
    }
}
