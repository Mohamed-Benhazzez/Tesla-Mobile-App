using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class GetTemperature : IModelExecute<double>
    {
        private readonly IClimateModelState _state = null;

        public GetTemperature(IClimateModelState state)
        {
            _state = state;
        }

        public IOperation<double> Operation
        {
            get
            {
                return new Operation<double>()
                {
                    Function = (token) =>
                    {
                        // Would ideally connect to the API and update this property rather than just retrieve it.
                        return Task.FromResult(_state.Temperature);
                    }
                };
            }
        }

        public int TimeoutMilliseconds { get; set; } = 10000;
    }
}
