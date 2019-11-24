using Game.Infraestructura;
using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Api.Infrastructure.Services;
using Game.Domain.Entities.UserAggregate;

namespace Game.Api.Infrastructure
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameContext(
            serviceProvider.GetRequiredService<DbContextOptions<GameContext>>()))
            {
                // Look for any board games.
                if (context.Players.Any())
                {
                    return;
                }

                var accountService = serviceProvider.GetService<IAccountService>();
                accountService.RegisterAsync(
                    new User
                    {
                        Email = "root@root.com"
                    }, "root123");

                context.Players.AddRange(
                new Player { FirstName = "Alex" },
                new Player { FirstName = "Alberto" },
                new Player { FirstName = "Miguel" },
                new Player { FirstName = "Luis" },
                new Player { FirstName = "Hugo" }
                );

                context.SaveChanges();
            }
        }
    }
}
