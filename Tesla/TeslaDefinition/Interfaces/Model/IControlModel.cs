using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Enums;

namespace TeslaDefinition.Interfaces.Model
{
    public interface IControlModel: IBaseModel
    {
        Task<bool> IssueCommand(CommandType type);
    }
}
