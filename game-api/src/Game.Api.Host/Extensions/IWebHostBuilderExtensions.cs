using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Api.Host.Extensions
{
    public static class IWebHostBuilderExtensions
    {
        public static IWebHost MigrateDatabase<TContext>(this IWebHost webHost) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TContext>();

                context.Database.Migrate();
                Infrastructure.DataGenerator.Initialize(services);
            }

            return webHost;
        }
    }
}
