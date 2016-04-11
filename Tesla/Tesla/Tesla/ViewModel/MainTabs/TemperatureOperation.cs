using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel.MainTabs
{
    public class TemperatureOperation : IOperation
    {

        IClimateModel _model = null;

        public TemperatureOperation(IClimateModel model)
        {
            _model = model;
        }

        public bool ChainedRollback { get; private set; } = false;

        public Func<IList<IResult>, object, Task> Function
        {
            get
            {
                return async (result, parameter) =>
                {
                    //await _model.IssueCommand(CommandType.Flash);
                };
            }
        }

        public Func<Task> Rollback { get { return null; } }
    }
}
