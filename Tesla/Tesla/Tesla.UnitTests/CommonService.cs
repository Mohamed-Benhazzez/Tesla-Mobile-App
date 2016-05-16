using Exrin.Abstraction;
using Exrin.Framework;
using Exrin.Insights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Service;
using TeslaService;

namespace Tesla.Tests
{
    public class CommonService
    {

        private static IExrinContainer _exrinContainer = new ExrinContainer(ApplicationInsights, DisplayService, ErrorHandlingService, NavigationService, StackRunner);
        public static IExrinContainer ExrinContainer
        {
            get
            {
                return _exrinContainer;
            }
        }

        private static IDisplayService _displayService = new DisplayService();
        public static IDisplayService DisplayService
        {
            get
            {
                return _displayService;
            }
        }

		private static IAuthenticationService _authenticationService = new AuthenticationService();
		public static IAuthenticationService AuthenticationService
		{
			get
			{
				return _authenticationService;
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

        private static INavigationService _navigationService = null;
        public static INavigationService NavigationService
        {
            get
            {
                return _navigationService;
            }
        }

        private static IStackRunner _stackRunner = null;
        public static IStackRunner StackRunner
        {
            get
            {
                return _stackRunner;
            }
        }
    }
}
