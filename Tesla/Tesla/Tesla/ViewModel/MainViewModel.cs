using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Exrin.Abstraction;
using TeslaDefinition.Interfaces;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public MainViewModel(IAuthModel authModel, IExrinContainer exrinContainer):
            base (authModel, exrinContainer, null)
        {
        }
        
    }
}
