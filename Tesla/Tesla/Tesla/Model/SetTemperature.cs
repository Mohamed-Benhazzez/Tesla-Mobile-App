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
	public class SetTemperature : IModelExecute<bool>
	{

		private readonly double _temperature = 0.0;
        private readonly IClimateModelState _state = null;

		public SetTemperature(double temperature, IClimateModelState state)
		{
			_temperature = temperature;
            _state = state;
		}
		
		public IOperation<bool> Operation
		{
			get
			{
				return new Operation<bool>()
				{
					Function = (token) =>
					{
                        var result = true; // Send to API here

                        if (result)
                            _state.Temperature = _temperature;

                        return Task.FromResult(result);
					}
				};
			}
		}

		public int TimeoutMilliseconds { get; set; } = 10000;
	}
}
