using Exrin.Framework;
using System;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
	public class PinVisualState : VisualState
    {
      
        public PinVisualState(IAuthModel model) : base(model) { }
		
        public string Pin
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
