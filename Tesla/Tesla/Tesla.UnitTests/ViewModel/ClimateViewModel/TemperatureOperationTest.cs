using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Enums;
using Xunit;

namespace Tesla.Tests.ViewModel.ClimateViewModel
{
    public class TemperatureOperationTest
    {


		public IOperation GetOperation(Temperature temperature)
		{
			return new TemperatureOperation(_model, temperature).Operation;
		}

		[Theory]
		[InlineData(CommandType.Flash)]
		[InlineData(CommandType.Honk)]
		public async Task StandardValuesTest(CommandType type)
		{
			//TODO: Pass api service, check its called

			var success = await GetOperation(type).Function(new System.Threading.CancellationToken());
			Assert.Equal(true, success);

		}

	}
}
