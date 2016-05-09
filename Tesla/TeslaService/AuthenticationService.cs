using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Service;

namespace TeslaService
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<bool> PinAuthenticate(string pin)
        {
            return Task.FromResult(true);
        }
    }
}
