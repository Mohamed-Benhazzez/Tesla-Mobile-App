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
        protected override IBaseModel Model { get; set; } = null;
        public PinVisualState(IPinModel model)
        {
            Model = model;
            HookEvents();           
        }

        protected override void OnModelPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(IPinModel.Pin))
            { HiddenPin = (Model as IPinModel).Pin; }
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
