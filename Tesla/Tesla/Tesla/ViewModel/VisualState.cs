using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class PinVisualState : VisualState
    {
      
        public PinVisualState(IAuthModel model) : base(model) { }

        //TODO: not liking this wire up, see if there is a better way
        protected override void OnModelStatePropertyChanged(string propertyName)
        {
            if (propertyName == nameof(IAuthModelState.Pin))
            { HiddenPin = (Model as IAuthModel).AuthModelState.Pin; }
        }      
                
        public string HiddenPin
        {
            get
            {
                var hiddenPin = Get<string>();
                return String.IsNullOrEmpty(hiddenPin) ? "enter pin" : new string('•', hiddenPin.Length);
            }
            set { Set(value); }
        }


    }
}
