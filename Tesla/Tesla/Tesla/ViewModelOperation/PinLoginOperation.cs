using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;

namespace Tesla.ViewModelOperation
{
    public class PinLoginOperation : IOperation
    {
        IPinModel _pinModel = null;
        public PinLoginOperation(IPinModel pinModel)
        {
            _pinModel = pinModel;
        }

        public bool ChainedRollback { get; private set; } = false;

        public Func<IResult, Task> Function
        {
            get
            {
                return async (result) =>
                {
                    if (await _pinModel.IsPinValid())
                    {
                        result.ResultAction = ResultType.Navigation;
                        result.Arguments = new NavigationArgs() { PageIndicator = PageLocator.Main.Main, StackType = Stacks.Main };
                    }
                    else
                    {
                        result.ResultAction = ResultType.Display;
                        result.Arguments = new DisplayArgs() { Message = "Invalid Pin Entered. Please try again." };
                    }
                };
            }
        }

        public Func<IResult, Task> Rollback { get { return null; } }
    }
}
