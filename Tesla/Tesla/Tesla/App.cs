using Exrin.Abstraction;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Tesla
{
	public class App : Application
    {

        public App()
        {
           new Bootstrapper().Init().Get<IStackRunner>().Run(TeslaDefinition.Stacks.Authentication);
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
