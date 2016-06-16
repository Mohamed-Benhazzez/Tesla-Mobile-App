using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TeslaDefinition;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class ViewBookingOperation : IOperation
    {
        private IServiceModel _model = null;

        public ViewBookingOperation(IServiceModel model)
        {
            _model = model;
        }

        public bool ChainedRollback { get; private set; } = false;

        public Func<IList<IResult>, object, CancellationToken, Task> Function
        {
            get
            {
                return (result, parameter, token) =>
                {
                    result.Add(new Result() { ResultAction = ResultType.Navigation, Arguments = new NavigationArgs() { Parameter = parameter, Key = Definition.ViewLocator.Booking.BookingMain, StackType = Stacks.Booking } });

                    return Task.FromResult(true);
                };
            }
        }

        public Func<Task> Rollback { get { return null; } }
    }
}
