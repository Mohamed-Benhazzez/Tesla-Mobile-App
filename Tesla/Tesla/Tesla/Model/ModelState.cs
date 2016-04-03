using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class AuthModelState: ModelState, IAuthModelState
    {
        public string Pin { get { return Get<string>(); } set { Set(value); } }

    }
}
