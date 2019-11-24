using Game.Domain.Entities.UserAggregate;
using System;

namespace Game.Domain.Entities.PlayerAgrgegate
{
    public class Player : Entity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now;
        public DateTime? GetOutDate { get; private set; }

        public Guid IdentityId { get; set; }
        public virtual User Identity { get; set; }

        public void GetOut()
        {
            if (GetOutDate.HasValue)
                throw new PlayerException("The player is already get out.");

            GetOutDate = DateTime.Now;
        }
    }
}
