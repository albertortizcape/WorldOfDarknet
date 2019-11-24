using Game.Api.Application.Queries.Account;
using Game.Domain.Entities.UserAggregate;
using System.Threading.Tasks;

namespace Game.Api.Infrastructure.Services
{
    public interface IAccountService
    {
        Task<LoginViewModel> LoginAsync(string email, string password);
        Task<RegisterViewModel> RegisterAsync(User user, string password);
    }
}