using Exrin.Abstraction;
using System.Threading.Tasks;
using Tesla.Model;
using TeslaDefinition.Enums;
using Xunit;

namespace Tesla.Tests.Model.ControlModel
{
	public class IssueControlCommandTest
    {

        public IOperation<bool> GetOperation(CommandType type)
        {
            return new IssueControlCommand(type).Operation;
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
