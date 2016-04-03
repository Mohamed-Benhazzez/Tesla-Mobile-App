using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Model
{
    public interface IPinModel: INotifyPropertyChanged
    {
        // State
        string Pin { get; set; }
        
        // State Validation
        Task<bool> IsPinValid();
    }
}
