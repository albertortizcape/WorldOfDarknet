using Game.Domain;
using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Infraestructura.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GameContext context;

        public PlayerRepository(GameContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public Player Add(Player player)
        {
            return context.Players.Add(player).Entity;
        }

        public async Task<Player> FindByIdAsync(Guid playerId)
        {
            return await context.Players.FindAsync(playerId);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await context.Players.ToListAsync();
        }

        public async Task<Player> GetByIdAsync(Guid playerId)
        {
            return await context.Players.FindAsync(playerId) ?? throw new KeyNotFoundException();
        }

        public void Remove(Player player)
        {
            context.Players.Remove(player);
        }

        public void Update(Player player)
        {
            context.Entry(player).State = EntityState.Modified;
        }
    }
}
