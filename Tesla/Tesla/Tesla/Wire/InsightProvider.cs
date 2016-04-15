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
        public Task<bool> Send(IInsightData data)
        {
            return Task.FromResult(true);
        }
    }
}
