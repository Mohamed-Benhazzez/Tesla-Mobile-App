using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Stack;
using TeslaDefinition;
using TeslaDefinition.Interfaces;
using Xamarin.Forms;

namespace Tesla
{
    public static class Bootstrapper
    {
        private readonly static AsyncLock _lock = new AsyncLock();
   

        public static void Init()
        {

            Injection.Init();

            InitServices();

            InitStacks();

            InitRunners();

            Injection.Complete();

        }
        
        /// <summary>
        /// Will initialize the basic navigation and display services
        /// </summary>
        private static void InitServices()
        {
            Injection.Register<IPageService, PageService>();
            Injection.Register<INavigationService, NavigationService>();
            Injection.Register<IDisplayService, DisplayService>();
        }

        private static void InitStacks()
        {
            Injection.Register<AuthenticationStack>();
            Injection.Register<MainStack>();
        }

        private static void InitRunners()
        {
            Injection.Register<IStackRunner, StackRunner>();
        }
       
    }
}
