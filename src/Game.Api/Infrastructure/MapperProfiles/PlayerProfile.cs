using AutoMapper;
using Game.Api.ViewModels;
using Game.Domain.Entities.PlayerAgrgegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Api.Infrastructure.MapperProfiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerViewModel, Player>();
            CreateMap<Player, PlayerViewModel>();

            CreateMap<CreatePlayerViewModel, Player>();
        }
    }
}
