using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class ClimateModel: BaseModel, IClimateModel
    {
        public ClimateModel(IDisplayService displayService, IErrorHandlingService errorHandlingService)
            : base(displayService, errorHandlingService)
        { }

    }
}
