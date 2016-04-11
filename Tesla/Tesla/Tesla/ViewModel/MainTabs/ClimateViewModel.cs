using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class ClimateViewModel : BaseViewModel
    {
        public ClimateViewModel(IClimateModel model, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner):
            base (displayService, navigationService, errorHandlingService, stackRunner, new ClimateVisualState(model))
        {
        }

    }
}
