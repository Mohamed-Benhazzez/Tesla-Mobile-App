using Exrin.Abstraction;
using Exrin.Framework;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Tesla
{
    public class App : Application
    {

        public App(IPlatformBootstrapper platformBootstrapper)
        {
            Bootstrapper.GetInstance(platformBootstrapper)
                .Init()
                .Get<INavigationService>()
                .Navigate(new StackOptions() { StackChoice = TeslaDefinition.Stacks.Authentication });
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
