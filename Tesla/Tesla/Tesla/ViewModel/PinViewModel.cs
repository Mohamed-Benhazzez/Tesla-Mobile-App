using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
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
    }
}
