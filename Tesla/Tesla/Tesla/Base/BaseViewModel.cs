using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition;
using TeslaDefinition.Interfaces;

namespace Tesla.Base
{
    public abstract class BaseViewModel : Exrin.Framework.ViewModel
    {        
        public BaseViewModel(IDisplayService displayService, INavigationService navigationService, 
            IErrorHandlingService errorHandlingService, IStackRunner stackRunner)
             : base(displayService, navigationService, errorHandlingService, stackRunner)
        {  
        }
        
    }
}
