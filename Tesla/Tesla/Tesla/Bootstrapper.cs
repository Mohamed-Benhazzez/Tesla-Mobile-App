using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Model;
using Tesla.Stack;
using Tesla.Wire;
using TeslaDefinition;
using TeslaDefinition.Interfaces;
using TeslaDefinition.Interfaces.Model;
using Xamarin.Forms;

namespace Tesla
{
    public static class Bootstrapper
    {
        private readonly static AsyncLock _lock = new AsyncLock();
        private readonly static IInjection _injection = new Injection();

        public static IInjection Init()
        {

            _injection.Init();

            InitServices();

            InitStacks();

            InitRunners();

            InitModels();

            _injection.Complete();

            return _injection;

        }
        
        /// <summary>
        /// Will initialize the basic navigation and display services
        /// </summary>
        private static void InitServices()
        {
            
            _injection.Register<IPageService, PageService>();
            _injection.Register<IErrorHandlingService, ErrorHandlingService>(); //TODO: Should be Insights with Error Tracking Capability
            _injection.Register<INavigationService, NavigationService>();
            _injection.Register<IDisplayService, DisplayService>();
        }

        private static void InitStacks()
        {
            _injection.Register<AuthenticationStack>();
            _injection.Register<MainStack>();
        }

        private static void InitRunners()
        {
            _injection.Register<IStackRunner, StackRunner>();
        }

        private static void InitModels()
        {
            _injection.Register<IPinModel, PinModel>();
        }
       
    }
}
