using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TeslaDefinition;

namespace Tesla.ViewModel
{
    public class CloseOperation: IOperation
    {
        public CloseOperation()
        {
        }

        public bool ChainedRollback { get; private set; } = false;

        public Func<IList<IResult>, object, CancellationToken, Task> Function
        {
            get
            {
                return (result, parameter, token) =>
                {
                    result.Add(new Result() { ResultAction = ResultType.Navigation, Arguments = new NavigationArgs() { Parameter = parameter, Key = Definition.ViewLocator.Main.Main, StackType = Stacks.Main } });

                    return Task.FromResult(true);
                };
            }
        }

        public Func<Task> Rollback { get { return null; } }
    }
}
