using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Exrin.Abstraction;
using TeslaDefinition.Interfaces;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public MainViewModel(IAuthModel authModel, IApplicationInsights applicationInsights, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner):
            base (authModel, applicationInsights, displayService, navigationService, errorHandlingService, stackRunner, null)
        {
        }
        
    }
}
