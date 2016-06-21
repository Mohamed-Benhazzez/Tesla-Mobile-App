using Exrin.Abstraction;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Tesla
{
    public class App : Application
    {
      
        public App(IPlatformBootstrapper platformBootstrapper)
        {
            Bootstrapper.GetInstance(platformBootstrapper).Init().Get<IStackRunner>().Run(TeslaDefinition.Stacks.Authentication);
            
            //Task.Run(async () =>
            //{
            //    await Task.Delay(2000);
            //    var url = $"http://exrin.net/tesla/";

            //    var entry = new AppLinkEntry
            //    {
            //        Title = "Tesla",
            //        Description = "Electric Cars",
            //        AppLinkUri = new Uri(url, UriKind.RelativeOrAbsolute),
            //        IsLinkActive = true
            //    };

            //    if (Device.OS == TargetPlatform.iOS)
            //        entry.Thumbnail = ImageSource.FromFile("logo.png");

            //    entry.KeyValues.Add("contentType", "Tesla");
            //    entry.KeyValues.Add("appName", "Tesla");
            //    entry.KeyValues.Add("companyName", "Tesla");

            //    Application.Current.AppLinks.RegisterLink(entry);
          
            //});
          

        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await Application.Current.MainPage.DisplayAlert("AppLink", uri.ToString(), "OK");
            //});


            //var data = uri.ToString().ToLowerInvariant();

            //if (!data.Contains("/tesla/"))
            //    return;

            //var id = data.Substring(data.LastIndexOf("/", StringComparison.Ordinal) + 1);

            //Navigate to a page based on the id.

            base.OnAppLinkRequestReceived(uri);
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
