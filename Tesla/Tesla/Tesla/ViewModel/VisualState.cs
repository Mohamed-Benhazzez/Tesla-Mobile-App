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
      
        public PinVisualState(IPinModel model) : base(model) { }

        protected override void OnModelStatePropertyChanged(string propertyName)
        {
            if (propertyName == nameof(IPinModelState.Pin))
            { HiddenPin = (Model as IPinModel).PinModelState.Pin; }
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
