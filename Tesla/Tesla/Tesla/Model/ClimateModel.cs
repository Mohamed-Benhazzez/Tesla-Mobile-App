using Exrin.Abstraction;
using Exrin.Framework;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;

namespace Tesla.Model
{
	public class ClimateModel : BaseModel, IClimateModel
	{

		private readonly IClimateService _service;

		public ClimateModel(IExrinContainer exrinContainer, IAuthModel authModel, IClimateService service)
			: base(exrinContainer, new ClimateModelState())
		{ _service = service; }

		public async Task<bool> ChangeTemperature(double movement)
		{
			return await SetTemperature(await GetTemperature() + movement);
		}

		public Task<double> GetTemperature()
		{
            return Execution.ModelExecute(new GetTemperature(ModelState as IClimateModelState));
		}

		public Task<bool> SetTemperature(double degrees)
		{
            return Execution.ModelExecute(new SetTemperature(degrees, ModelState as IClimateModelState));
		}
	}
}
