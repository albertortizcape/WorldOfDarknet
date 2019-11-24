using System.Threading.Tasks;

namespace Game.Domain.Entities.UserAggregate
{
    public interface IUserService
    {
        Task<User> LoginAsync(string userName, string password);
        Task<User> RegisterAsync(User user, string password);
    }
}
