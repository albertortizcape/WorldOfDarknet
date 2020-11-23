using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Game.Api.SignalR
{
    public class GameHub : Hub<IGameHub>
    {
        private readonly ILogger<GameHub> logger;

        public GameHub(ILogger<GameHub> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override Task OnConnectedAsync()
        {
            logger.LogInformation($"New connection client: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            logger.LogInformation($"Client disconnected: {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task PlayerJoin(string playerName)
        {
            logger.LogInformation($"Player joined {playerName}");
            await Clients.All.PlayerJoin(playerName);
        }

        public async Task PlayerStats(string stats)
        {
            await Clients.All.PlayerStats(stats);
        }

        public async Task DiceRolls(string diceValues)
        {
            await Clients.All.DiceRolls(diceValues);
        }
    }
}
