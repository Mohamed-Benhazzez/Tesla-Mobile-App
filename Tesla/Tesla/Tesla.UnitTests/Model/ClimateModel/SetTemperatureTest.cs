using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Model;
using TeslaDefinition.Interfaces.Model;
using Xunit;

namespace Tesla.Tests.Model.ClimateModel
{
    public class SetTemperatureTest
    {
        private IClimateModelState _state = null;

        private void SetupState()
        {
            var state = new Moq.Mock<IClimateModelState>();

            state.SetupAllProperties();

            _state = state.Object;


        }
        public IOperation<bool> GetOperation(double temperature)
        {
            SetupState();
            return new SetTemperature(temperature, _state).Operation;
        }

        [Theory]
        [InlineData(-1.1)]
        [InlineData(1.1)]
        [InlineData(24.0)]
        [InlineData(42.6)]
        public async Task StandardValuesTest(double temperature)
        {
            var success = await GetOperation(temperature).Function(new System.Threading.CancellationToken());
            Assert.Equal(true, success);
            
            // Reflects in the model state
            Assert.Equal(temperature, _state.Temperature);
        }


    }
}
