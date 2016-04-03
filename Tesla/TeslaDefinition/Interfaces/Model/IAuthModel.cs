using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Model
{
    public interface IAuthModel: IBaseModel
    {
        // State
        IAuthModelState AuthModelState { get; }
        
        // State Validation
        Task<bool> IsAuthenticated();
    }
}
