using Exrin.Abstraction;
using Exrin.Framework;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
	public class ClimateModel : BaseModel, IClimateModel
    {
        public ClimateModel(IDisplayService displayService, IApplicationInsights applicationInsights, IErrorHandlingService errorHandlingService, IAuthModel authModel)
            : base(displayService, applicationInsights, errorHandlingService, new ClimateModelState())
        { }

		public async Task<bool> ChangeTemperature(double movement)
		{
			return await SetTemperature(await GetTemperature() + movement);			
		}

		public Task<double> GetTemperature()
		{
			(base.ModelState as IClimateModelState).Temperature = 24;
			// Would ideally connect to the API then update this property rather than just retrieve it.
			return Task.FromResult((base.ModelState as IClimateModelState).Temperature);
		}

		public Task<bool> SetTemperature(double degrees)
		{
			return Execution.ModelExecute(new SetTemperature(degrees));
		}
	}
}
