using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Game.Api.Infrastructure.Queries;
using Game.Api.ViewModels;
using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IPlayerQuery _playerQuery;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService,
                                IPlayerQuery playerQuery,
                                IMapper mapper)
        {
            this._playerService = playerService;
            this._playerQuery = playerQuery;
            this._mapper = mapper;
        }

        [HttpGet("{playerId}",  Name = "GetPlayer")]
        [ProducesResponseType(typeof(IEnumerable<Player>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlayerAsync(Guid playerId)
        {
            var players = await _playerQuery.GetAllPlayersAsync();
            var player = players.FirstOrDefault(p => p.Id == playerId);

            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Player>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var players = await _playerQuery.GetAllPlayersAsync();
            return Ok(players);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePlayerAsync([FromBody]CreatePlayerViewModel player)
        {
            Player playerToAdd = _mapper.Map<Player>(player);

            try
            {
                playerToAdd = await _playerService.CreateAsync(playerToAdd);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }

            PlayerViewModel viewModel = _mapper.Map<PlayerViewModel>(playerToAdd);

            return CreatedAtRoute("GetPlayer", new { playerId = viewModel.Id }, viewModel);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(PlayerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOutPlayerAsync(Guid playerId)
        {
            try
            {
                Player player = await _playerService.GetByIdAsync(playerId);
                player.GetOut();

                player = await _playerService.UpdateAsync(player);

                PlayerViewModel viewModel = _mapper.Map<PlayerViewModel>(player);

                return Ok(viewModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}