using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class PinModel: BaseModel, IPinModel
    {
        public string Pin { get; set; }
        public string HiddenPin { get; set; }
    }
}
