using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Tesla.Control;
using Tesla.ViewModelExecute;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces;

namespace Tesla.ViewModel
{
    public class PinViewModel : BaseViewModel
    {
        public PinViewModel(IAuthModel model, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner) :
            base(displayService, navigationService, errorHandlingService, stackRunner, new PinVisualState(model))
        {
            Model = model;
        }

        private IAuthModel Model { get; set; }

        public IRelayCommand KeyPressCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new PinLoginViewModelExecute(Model, Keypad.BackCharacter));
                });
            }
        }

        
    }
}
