using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.ViewModelOperation;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModelExecute
{
    public class PinLoginViewModelExecute : BaseViewModelExecute 
    {
        public PinLoginViewModelExecute(IAuthModel model, string backCharacter)
        {
            TimeoutMilliseconds = 10000;
            Operations.Add(new PinLoginOperation(model, backCharacter));
        }
    }
}
