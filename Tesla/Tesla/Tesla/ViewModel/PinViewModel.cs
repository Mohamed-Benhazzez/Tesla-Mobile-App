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
        public PinViewModel(IAuthModel model, IExrinContainer exrinContainer) :
            base(model, exrinContainer, new PinVisualState(model))
        {
           
        }
      
        public IRelayCommand KeyPressCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new PinLoginViewModelExecute(base.AuthModel, Keypad.BackCharacter));
                });
            }
        }
                
    }
}
