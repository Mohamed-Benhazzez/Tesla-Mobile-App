using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;

namespace Tesla.ViewModel
{
    public class ClimateViewModel : BaseViewModel
    {
        public ClimateViewModel(IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner):
            base (displayService, navigationService, errorHandlingService, stackRunner, null)
        {
        }

    }
}
