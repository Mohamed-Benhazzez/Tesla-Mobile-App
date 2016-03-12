using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Tesla.Control;
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
        
        private RelayCommand _keyPressCommand = null;
        public RelayCommand KeyPressCommand
        {
            get
            {
                if (_keyPressCommand == null)
                    _keyPressCommand = new RelayCommand((parameter) =>
                    {
                        var character = Convert.ToString(parameter);
                        var pin = Model.Pin;

                        if (character != null)
                            switch (character)
                            {
                                case Keypad.BackCharacter:
                                    if (!String.IsNullOrEmpty(pin) && pin.Length > 0)
                                        Model.Pin = pin.Substring(0, pin.Length - 1);
                                    break;
                                default:
                                    Model.Pin = pin += character;
                                    break;
                            }
                            
                    });

                return _keyPressCommand;
            }

        }

    }
}
