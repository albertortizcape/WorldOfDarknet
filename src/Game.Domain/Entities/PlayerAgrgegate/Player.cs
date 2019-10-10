using System;

namespace Game.Domain.Entities.PlayerAgrgegate
{
    public class Player : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now;
        public DateTime? GetOutDate { get; private set; }

        public void GetOut()
        {
            if (GetOutDate.HasValue)
                throw new PlayerException("The player is already get out.");

            GetOutDate = DateTime.Now;
        }
    }
}
