using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Exrin.Abstraction;
using TeslaDefinition.Interfaces;

namespace Tesla.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public MainViewModel(IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner):
            base (displayService, navigationService, errorHandlingService, stackRunner)
        {
        }
        
    }
}
