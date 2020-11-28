using System;

namespace Game.Api.Application.Queries.Account
{
    public class LoginViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
