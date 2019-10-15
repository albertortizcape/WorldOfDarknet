using System;
using Game.Infraestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Api.Host.Extensions
{
    public static class IServiceCollectionExtensions
    { 
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "GameDB");
            }, ServiceLifetime.Scoped);

            return services;
        }
    }
}
