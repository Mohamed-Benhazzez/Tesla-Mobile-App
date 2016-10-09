using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Proxy
{
    public class InsightProvider : IInsightsProvider
    {
      
        public Task Record(IInsightData data)
        {
            throw new NotImplementedException();
        }
    }
}
