using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel.MainTabs
{
    public class HonkOperation : IOperation
    {
        IControlModel _model = null;
        
        public HonkOperation(IControlModel model)
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

                   
                };
            }
        }

        public Func<Task> Rollback { get { return null; } }
    }
}