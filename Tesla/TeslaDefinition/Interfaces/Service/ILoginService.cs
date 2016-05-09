﻿using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Service
{
    public interface IAuthenticationService: IService
    {

        Task<bool> PinAuthenticate(string pin);

    }
}
