using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Base
{
    public class BaseModel: Exrin.Framework.Model
    {

        public BaseModel()
        {
            Execution = new ModelExecution()
            {
                HandleTimeout = ()=> { return Task.FromResult(0); },
                HandleUnhandledException = (exception) => { return Task.FromResult(true); }
            };
        }

    }
}
