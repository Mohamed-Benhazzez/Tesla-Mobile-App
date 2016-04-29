using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Enums;

namespace Tesla.Model
{
    public class IssueControlCommand : IModelExecute<bool>
    {
        CommandType _command;
        public IssueControlCommand(CommandType command)
        {
            _command = command;
        }
        
        public IOperation<bool> Operation
        {
            get
            {
                return new Operation<bool>()
                {
                    Function = async (token) =>
                    {
                        await Task.Delay(1000);
                        return true;
                    }
                };
            }
        }

        public int TimeoutMilliseconds { get; set; } = 10000;
    }
}
