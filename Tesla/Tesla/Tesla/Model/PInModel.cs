using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class PinModel : BaseModel, IPinModel
    {
        private string _pin = "";
        public string Pin { get { return _pin; } set { _pin = value; HiddenPin = value; OnPropertyChanged(); } }

        private string _hiddenPin = "";
        public string HiddenPin { get { return String.IsNullOrEmpty(_hiddenPin) ? "enter pin" : new string('•', _hiddenPin.Length); } set { _hiddenPin = value; OnPropertyChanged(); } }

        public Task<bool> IsPinValid()
        {
            return Execution.ModelExecute(new IsPinValidModelExecute(Pin));
        }
    }
    
}
