using Game.Domain.Entities.PlayerAgrgegate;

namespace Game.Domain.Entities.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Player Player { get; set; }
    }
}
