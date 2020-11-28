using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Api.Infrastructure.Authentication
{
    public class AuthenticationSettings
    {
        public string Key { get; set; }
        public int ExpireTokenDays { get; set; }
    }
}
