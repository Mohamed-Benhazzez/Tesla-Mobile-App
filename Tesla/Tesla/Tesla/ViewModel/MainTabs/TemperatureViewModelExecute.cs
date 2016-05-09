using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Enums;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;

namespace Tesla.ViewModel.MainTabs
{
    public class TemperatureViewModelExecute : BaseViewModelExecute
    {
        public TemperatureViewModelExecute(IClimateModel model, Temperature temperature)
        {
            TimeoutMilliseconds = 10000;
            Operations.Add(new TemperatureOperation(model, temperature));
        }
    }
}
