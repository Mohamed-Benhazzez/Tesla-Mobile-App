using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Enums;
using TeslaDefinition.Interfaces.Model;
using Xunit;
using Moq;

namespace Tesla.Tests.ViewModel.ClimateViewModel
{
	public class TemperatureOperationTest
	{
		IClimateModel _model = null;
		Mock<IClimateModel> _mock = null;
		private void Setup()
		{
			if (_model != null)
				return;

			_mock = new Moq.Mock<IClimateModel>(MockBehavior.Loose);
			_mock.Setup(x => x.ChangeTemperature(1.0)).Returns(Task.FromResult(true));

			_model = _mock.Object;
		}

		public IOperation GetOperation(Temperature temperature)
		{
			Setup();
			return new TemperatureOperation(_model, temperature);
		}

		[Theory]
		[InlineData(Temperature.Down)]
		[InlineData(Temperature.Up)]
		public async Task StandardValuesTest(Temperature temperature)
		{
			IList<IResult> result = new List<IResult>();
			var parameter = new object();
			await GetOperation(temperature).Function(result, parameter, (new CancellationTokenSource()).Token);

			switch (temperature)// Check that Temperature change function was called	
			{
				case Temperature.Down:
					_mock.Verify(x => x.ChangeTemperature(-1.0));
					break;
				case Temperature.Up:
					_mock.Verify(x => x.ChangeTemperature(1.0));
					break;
			}

			// Check IResult List for results
			Assert.Equal(0, result.Count);

		}

	}
}
