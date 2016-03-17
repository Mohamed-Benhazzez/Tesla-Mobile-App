using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Service
{
    public interface ILoginService
    {

        Task<bool> PinAuthenticate(string pin);

    }
}
