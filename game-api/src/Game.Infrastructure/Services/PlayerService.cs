using Game.Domain.Entities.PlayerAgrgegate;
using System;
using System.Threading.Tasks;

namespace Game.Infraestructura.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task<Player> CreateAsync(Player player)
        {
            player = playerRepository.Add(player);
            await playerRepository.UnitOfWork.SaveChangesAsync();
            return player;
            
        }

        public async Task DeleteAsync(Player player)
        {
            playerRepository.Remove(player);
            await playerRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<Player> GetByIdAsync(Guid playerId)
        {
            return await playerRepository.GetByIdAsync(playerId);
        }

        public async Task<Player> UpdateAsync(Player player)
        {
            playerRepository.Update(player);
            await playerRepository.UnitOfWork.SaveChangesAsync();
            return player;
        }
    }
}
