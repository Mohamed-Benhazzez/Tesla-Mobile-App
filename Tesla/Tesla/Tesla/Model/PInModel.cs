﻿using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class PinModel : BaseModel, IPinModel
    {
        public PinModel(IDisplayService displayService, IErrorHandlingService errorHandlingService)
            : base(displayService, errorHandlingService)
        { }
        
        public string Pin { get { return Get<string>(); } set { Set(value); } }

       
        public Task<bool> IsPinValid()
        {
            return Execution.ModelExecute(new IsPinValidModelExecute(Pin));
        }
    }
    
}
