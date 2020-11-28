using AutoMapper;
using Game.Api.Application.Commands.Player;
using Game.Api.Application.Queries.Player;
using Game.Domain.Entities.PlayerAgrgegate;

namespace Game.Api.Infrastructure.MapperProfiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerViewModel, Player>();
            CreateMap<Player, PlayerViewModel>();

            CreateMap<CreatePlayerCommand, Player>();
        }
    }
}
