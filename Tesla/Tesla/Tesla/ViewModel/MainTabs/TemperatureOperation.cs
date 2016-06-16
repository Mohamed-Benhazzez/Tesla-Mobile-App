using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeslaDefinition.Enums;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;

namespace Tesla.ViewModel.MainTabs
{
	public class TemperatureOperation : IOperation
	{
		private IClimateModel _model = null;
		private readonly Temperature _temperature;

		public TemperatureOperation(IClimateModel model, Temperature temperature)
		{
			_model = model;
			_temperature = temperature;
		}

		public bool ChainedRollback { get; private set; } = false;

		public Func<IList<IResult>, object, CancellationToken, Task> Function
		{
			get
			{
				return async (result, parameter, token) =>
				{
					var change = 0;
					switch (_temperature)
					{
						case Temperature.Up:
							change += 1;
							break;
						case Temperature.Down:
							change -= 1;
							break;
					}
					await _model.ChangeTemperature(change);
				};
			}
		}

		public Func<Task> Rollback { get { return null; } }
	}
}
