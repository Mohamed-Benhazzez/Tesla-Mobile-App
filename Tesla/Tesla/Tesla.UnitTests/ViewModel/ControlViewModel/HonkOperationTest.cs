using Exrin.Abstraction;
using Moq;
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

namespace Tesla.Tests.ViewModel.ControlViewModel
{
    public class HonkOperationTest
    {

		IControlModel _model = null;
		Mock<IControlModel> _mock = null;
		private void Setup()
		{
			if (_model != null)
				return;

			_mock = new Moq.Mock<IControlModel>(MockBehavior.Loose);
			_mock.Setup(x => x.IssueCommand(CommandType.Flash)).Returns(Task.FromResult(true));

			_model = _mock.Object;
		}

		public IOperation GetOperation()
		{
			Setup();
			return new FlashOperation(_model);
		}

		[Fact]
		public async Task StandardValuesTest()
		{
			IList<IResult> result = new List<IResult>();
			var parameter = new object();
			await GetOperation().Function(result, parameter, (new CancellationTokenSource()).Token);

			_mock.Verify(x => x.IssueCommand(CommandType.Flash));

			// Check IResult List for results
			Assert.Equal(0, result.Count);
		}

	}
}
