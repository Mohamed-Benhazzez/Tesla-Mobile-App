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

		{   // Would ideally connect to the API then update this property rather than just retrieve it.
			return Task.FromResult((base.ModelState as IClimateModelState).Temperature);
		}

		public async Task<bool> SetTemperature(double degrees)
		{
			var result = await Execution.ModelExecute(new SetTemperature(degrees));

			if (result)
				(base.ModelState as IClimateModelState).Temperature = degrees;

			return result;
		}
	}
}
