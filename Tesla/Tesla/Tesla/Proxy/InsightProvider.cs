namespace Tesla.Proxy
{
    using Exrin.Abstraction;
    using System;
    using System.Threading.Tasks;

    public class InsightProvider : IInsightsProvider
    {
      
        public Task Record(IInsightData data)
        {
            throw new NotImplementedException();
        }
    }
}
