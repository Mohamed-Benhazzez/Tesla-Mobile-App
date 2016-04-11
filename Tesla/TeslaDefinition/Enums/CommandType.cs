using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Enums
{
    [Flags]
    public enum CommandType
    {
        Honk = 1,
        Flash = 2
    }
}
