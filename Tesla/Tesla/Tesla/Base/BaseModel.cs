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
        public BaseModel(IExrinContainer exrinContainer, IModelState modelState)
            :base(exrinContainer, modelState)
        {           
        }
    }
}
