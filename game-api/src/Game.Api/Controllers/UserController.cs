using Game.Api.Application.Commands.Account;
using Game.Api.Application.Queries.Account;
using Game.Api.Infrastructure.Services;
using Game.Api.ViewModels.Account;
using Game.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Game.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService accountService;

        public UserController(IAccountService  accountService)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCommand loginCommand)
        {
            LoginViewModel userViewModel = await accountService.LoginAsync(loginCommand.Email, loginCommand.Password);

            if (userViewModel == null)
                return BadRequest(new { message = "Email or password are incorrect" });

            return Ok(userViewModel);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterUserCommand registerUserCommand)
        {
            var user = new User()
            {
                Email = registerUserCommand.Email
            };

            RegisterViewModel registered = await accountService.RegisterAsync(user, registerUserCommand.Password);

            if (registered == null)
                return BadRequest(new { message = "Email or password are incorrect" });

            return Ok(registered);
        }
    }
}