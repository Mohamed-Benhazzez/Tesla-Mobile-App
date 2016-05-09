using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Model
{
	public class SetTemperature : IModelExecute<bool>
	{

		private readonly double _temperature = 0.0;

		public SetTemperature(double temperature)
		{
			_temperature = temperature;
		}
		
		public IOperation<bool> Operation
		{
			get
			{
				return new Operation<bool>()
				{
					Function = (token) =>
					{

						return Task.FromResult(true);
					}
				};
			}
		}

		public int TimeoutMilliseconds { get; set; } = 10000;
	}
}
