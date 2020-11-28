using System;
using System.Threading.Tasks;

namespace Game.Domain.Entities.PlayerAgrgegate
{
    public interface IPlayerService
    {
        Task<Player> GetByIdAsync(Guid playerId);
        Task<Player> CreateAsync(Player player);
        Task<Player> UpdateAsync(Player player);
        Task DeleteAsync(Player player);
    }
}
