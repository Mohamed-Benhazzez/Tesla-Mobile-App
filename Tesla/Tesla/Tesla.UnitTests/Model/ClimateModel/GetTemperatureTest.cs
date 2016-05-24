using Exrin.Abstraction;
using System.Threading.Tasks;
using Tesla.Model;
using TeslaDefinition.Interfaces.Model;
using Xunit;

namespace Tesla.Tests.Model.ClimateModel
{
    public class GetTemperatureTest
    {
        private IClimateModelState _state = null;

        private void SetupState()
        {
            var state = new Moq.Mock<IClimateModelState>();

            state.SetupAllProperties();
            state.Object.Temperature = 24;
            _state = state.Object;
        }

        public IOperation<double> GetOperation()
        {
            SetupState();
            return new GetTemperature(_state).Operation;
        }

        [Fact]
        public async Task StandardValuesTest()
        {
            var returned = await GetOperation().Function(new System.Threading.CancellationToken());
            Assert.Equal(24.0, returned);
        }
    }
}
