using Game.Api.Host.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Game.Api.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<Game.Infraestructura.GameContext>()
                .Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
