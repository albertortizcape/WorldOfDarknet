using Game.Api.Application.Queries.Account;
using Game.Api.Infrastructure.Authentication;
using Game.Domain.Entities.UserAggregate;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Game.Api.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService userService;
        private readonly ITokenFactory tokenFactory;
        private readonly AuthenticationSettings settings;

        public AccountService(IUserService userService, ITokenFactory tokenFactory, IOptions<AuthenticationSettings> authSettings)
        {
            settings = authSettings.Value;
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));
        }
        
        public async Task<LoginViewModel> LoginAsync(string email, string password)
        {
            var user = await userService.LoginAsync(email, password);

            if (user == null)
                return null;

            DateTime tokenExpiration = DateTime.UtcNow.AddDays(settings.ExpireTokenDays);

            var loginViewModel = new LoginViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Expires = tokenExpiration,
                Token = tokenFactory.Create(user, tokenExpiration)
            };

            return loginViewModel;
        }

        public async Task<RegisterViewModel> RegisterAsync(User user, string password)
        {
            User userRegistered = await userService.RegisterAsync(user, password);

            return new RegisterViewModel { Email = userRegistered.Email };
        }
    }
}
