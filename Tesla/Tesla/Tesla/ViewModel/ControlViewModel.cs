using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces;

namespace Tesla.ViewModel
{
    public class ControlViewModel: BaseViewModel
    {

        public ControlViewModel(IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner):
            base (displayService, navigationService, errorHandlingService, stackRunner)
        {
        }

    }
}
