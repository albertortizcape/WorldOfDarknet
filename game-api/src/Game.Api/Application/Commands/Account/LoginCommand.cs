using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Api.ViewModels.Account
{
    public class LoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
