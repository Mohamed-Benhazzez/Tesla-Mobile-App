using Tesla.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tesla.Tests.Wire
{
    public class InsightProviderTest
    {

		public InsightProvider GetInsightProvider()
		{
			return new InsightProvider();
		}

		[Fact]
		public void Record()
		{
			var provider = GetInsightProvider();

			Assert.ThrowsAsync<NotImplementedException>(async () => await provider.Record(new Exrin.Insights.InsightData()));

		}


	}
}
