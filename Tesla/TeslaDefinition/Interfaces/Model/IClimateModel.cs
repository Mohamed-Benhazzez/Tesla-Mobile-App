using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Model
{
    public interface IClimateModel: IBaseModel
    {
		Task<bool> SetTemperature(double temperature);

		Task<bool> ChangeTemperature(double movement);

		Task<double> GetTemperature();
	}
}
