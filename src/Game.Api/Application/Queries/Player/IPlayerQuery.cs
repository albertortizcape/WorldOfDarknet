using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Api.Application.Queries.Player
{
    public interface IPlayerQuery
    {
        Task<List<PlayerViewModel>> GetAllPlayersAsync();
    }
}