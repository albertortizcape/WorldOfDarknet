using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Api.Application.Queries.Player
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? GetOutDate { get; set; }
    }
}
