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
    public class BaseViewModel : Exrin.Framework.ViewModel
    {        
        public BaseViewModel(IApplicationInsights applicationInsights, IDisplayService displayService, INavigationService navigationService, 
            IErrorHandlingService errorHandlingService, IStackRunner stackRunner, IVisualState visualState, [CallerFilePath] string caller = nameof(BaseViewModel))
             : base(applicationInsights, displayService, navigationService, errorHandlingService, stackRunner, visualState, caller)
        {  
        }
        
    }
}
