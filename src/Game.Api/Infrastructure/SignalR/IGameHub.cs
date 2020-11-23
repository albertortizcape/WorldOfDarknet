using System.Threading.Tasks;

namespace Game.Api.Infrastructure.SignalR
{
    public interface IGameHub
    {
        Task PlayerJoin(string playerName);
        Task PlayerStats(string stats);
        Task DiceRolls(string diceValues);
    }
}
