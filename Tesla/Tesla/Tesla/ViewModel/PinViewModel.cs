using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Base;
using Tesla.Control;
using Tesla.ViewModelExecute;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class PinViewModel : BaseViewModel
    {
        public PinViewModel(IAuthModel model, IApplicationInsights applicationInsights, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner) :
            base(applicationInsights, displayService, navigationService, errorHandlingService, stackRunner, new PinVisualState(model))
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
