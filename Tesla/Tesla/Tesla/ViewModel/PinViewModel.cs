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
        public PinViewModel(IPinModel model, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner) :
            base(displayService, navigationService, errorHandlingService, stackRunner)
        {
            Model = model;
            VisualState = new PinVisualState(model);
        }

        private IPinModel Model { get; set; }

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

        public override IVisualState VisualState { get; set; } 
    }
}
