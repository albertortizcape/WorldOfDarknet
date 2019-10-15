using AutoMapper;
using Game.Api.ViewModels;
using Game.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Api.Infrastructure.Queries
{
    public class PlayerQuery : IPlayerQuery
    {
        private readonly GameContext context;
        private readonly IMapper mapper;

        public PlayerQuery(GameContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<PlayerViewModel>> GetAllPlayersAsync()
        {
            var players = await context.Players.ToListAsync();

            return mapper.Map<List<PlayerViewModel>>(players);
        }
    }
}
