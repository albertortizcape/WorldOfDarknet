using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Domain.Entities.PlayerAgrgegate
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player Add(Player player);
        void Update(Player player);
        Task<Player> GetByIdAsync(Guid playerId);
        Task<Player> FindByIdAsync(Guid playerId);
        void Remove(Player player);
        Task<IEnumerable<Player>> GetAllAsync();
    }
}
