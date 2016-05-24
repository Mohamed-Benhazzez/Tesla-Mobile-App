using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Wire
{
    public class InsightProvider : IInsightsProvider
    {
      
        Task IInsightsProvider.Record(IInsightData data)
        {
            throw new NotImplementedException();
        }
    }
}
