using Game.Api.Application.Queries.Account;
using Game.Api.Infrastructure.Authentication;
using Game.Domain.Entities.UserAggregate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService userService;
        private readonly AuthenticationSettings settings;

        public AccountService(IUserService userService, IOptions<AuthenticationSettings> authSettings)
        {
            settings = authSettings.Value;
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        
        public async Task<LoginViewModel> LoginAsync(string email, string password)
        {
            var user = await userService.LoginAsync(email, password);

            if (user == null)
                return null;

            var loginViewModel = new LoginViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Expires = DateTime.UtcNow.AddDays(settings.ExpireTokenDays)
            };

            // authenticado, a por el token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = loginViewModel.Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            loginViewModel.Token = tokenHandler.WriteToken(token);

            return loginViewModel;
        }

        public async Task<RegisterViewModel> RegisterAsync(User user, string password)
        {
            User userRegistered = await userService.RegisterAsync(user, password);

            return new RegisterViewModel { Email = userRegistered.Email };
        }
    }
}
