using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Model
{
    public interface IPinModel
    {
        // State
        string Pin { get; set; }
        string HiddenPin { get; set; }

        // State Validation
        Task<bool> IsPinValid();
    }
}
