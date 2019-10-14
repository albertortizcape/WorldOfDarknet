using Game.Infraestructura;
using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    return;   // Data was already seeded
                }

                context.Players.AddRange(
                new Player { Name = "Alex" },
                new Player { Name = "Alberto" },
                new Player { Name = "Miguel" },
                new Player { Name = "Luis" },
                new Player { Name = "Hugo" }
                );

                context.SaveChanges();
            };
        }
    }
}
