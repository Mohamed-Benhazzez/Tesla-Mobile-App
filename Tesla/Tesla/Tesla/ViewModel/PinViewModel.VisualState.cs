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
        private readonly IPinModel _model = null;
        public PinVisualState(IPinModel model)
        {
            _model = model;
            model.PropertyChanged += OnPropertyChanged;
        }
       
        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_model.Pin))
            { HiddenPin = _model.Pin; }
        }

        public override void Dispose()
        {
            _model.PropertyChanged -= OnPropertyChanged;

            base.Dispose();
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
