using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Game.Api.Infrastructure.Queries;
using Game.Api.ViewModels;
using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private readonly IPlayerQuery playerQuery;
        private readonly IMapper mapper;

        public PlayerController(IPlayerService playerService, IPlayerQuery playerQuery, IMapper mapper)
        {
            this.playerService = playerService;
            this.playerQuery = playerQuery;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(IEnumerable<Player>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ItemsAsync()
        {
            var players = await playerQuery.GetAllPlayersAsync();

            return Ok(players);
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(PlayerViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePlayerAsync([FromBody]CreatePlayerViewModel player)
        {
            Player playerToAdd = mapper.Map<Player>(player);

            try
            {
                playerToAdd = await playerService.CreateAsync(playerToAdd);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }

            PlayerViewModel viewModel = mapper.Map<PlayerViewModel>(playerToAdd);

            return Ok(viewModel);
        }

        [Route("{playerId}/getOut")]
        [HttpPost]
        [ProducesResponseType(typeof(PlayerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOutPlayerAsync(Guid playerId)
        {
            try
            {
                Player player = await playerService.GetByIdAsync(playerId);
                player.GetOut();

                player = await playerService.UpdateAsync(player);

                PlayerViewModel viewModel = mapper.Map<PlayerViewModel>(player);

                return Ok(viewModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}