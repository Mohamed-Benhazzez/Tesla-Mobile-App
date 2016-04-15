using Exrin.Abstraction;
using Exrin.Framework;
using Exrin.Insights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Tests
{
    public class CommonService
    {
        private static IDisplayService _displayService = new DisplayService();
        public static IDisplayService DisplayService
        {
            get
            {
                return _displayService;
            }
        }

        private static IApplicationInsights _applicationInsights = new ApplicationInsights(new MemoryInsightStorage(), new DeviceInfo());
        public static IApplicationInsights ApplicationInsights
        {
            get
            {
                return _applicationInsights;
            }
        }

        private static IErrorHandlingService _errorHandlingService = new ErrorHandlingService(DisplayService);
        public static IErrorHandlingService ErrorHandlingService
        {
            get
            {
                return _errorHandlingService;
            }
        }
    }
}
