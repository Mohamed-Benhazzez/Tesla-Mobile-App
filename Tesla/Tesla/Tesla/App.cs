using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeslaDefinition.Interfaces;
using Xamarin.Forms;

namespace Tesla
{
    public class App : Application
    {
        public App()
        {

            Bootstrapper.Init();

            Injection.Get<IStackRunner>().Run(TeslaDefinition.Stacks.Authentication);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
