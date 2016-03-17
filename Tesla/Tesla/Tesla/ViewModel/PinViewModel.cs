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

namespace Tesla.ViewModel
{
    public class PinViewModel : BaseViewModel
    {
        public PinViewModel(IPinModel model)
        {
            Model = model;
        }

        public IPinModel Model { get; set; }
        
        private IRelayCommand _keyPressCommand = null;
        public IRelayCommand KeyPressCommand
        {
            get
            {
                return _keyPressCommand ??
                       (_execution.ViewModelExecute(new PinLoginViewModelExecute(Model, Keypad.BackCharacter)));
            }

        }

    }
}
