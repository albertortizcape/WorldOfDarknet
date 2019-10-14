using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Api.ViewModels;

namespace Game.Api.Infrastructure.Queries
{
    public interface IPlayerQuery
    {
        Task<List<PlayerViewModel>> GetAllPlayersAsync();
    }
}