using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Stack;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla
{
    public static class Bootstrapper
    {
        private readonly static AsyncLock _lock = new AsyncLock();
   

        public static void Init()
        {

            InitServices();

        }



       

        /// <summary>
        /// Will initialize the basic navigation and display services
        /// </summary>
        private static void InitServices()
        {
            Injection.RegisterService<IPageService, PageService>();
            Injection.RegisterService<INavigationService, NavigationService>();
            Injection.RegisterService<IDisplayService, DisplayService>();
        }


       
    }
}
