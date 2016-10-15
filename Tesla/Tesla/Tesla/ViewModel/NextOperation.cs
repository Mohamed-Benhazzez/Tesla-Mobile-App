using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeslaDefinition;

namespace Tesla.ViewModel
{
    public class NextOperation : IOperation
    {
        public NextOperation()
        {
        }

        public bool ChainedRollback { get; private set; } = false;

        public Func<IList<IResult>, object, CancellationToken, Task> Function
        {
            get
            {
                return async (result, parameter, token) =>
                {
                    await Task.Delay(0);
                    result.Add(new Result() { ResultAction = ResultType.Navigation, Arguments = new NavigationArgs() { Key = Definition.ViewLocator.Climate.ClimateTwo, StackType = Stacks.Climate } });
                };
            }
        }

        public Func<Task> Rollback { get { return null; } }
    }
}
