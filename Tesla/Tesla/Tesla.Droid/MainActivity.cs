using Android.App;
using Android.Content;
using Android.OS;
using Exrin.Framework;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace Tesla.Droid
{
    [Activity(Label = "Tesla", MainLauncher = true, Theme = "@style/main", Icon = "@drawable/icon")]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
     Categories = new[]
     {
         Android.Content.Intent.CategoryDefault,
         Android.Content.Intent.CategoryBrowsable
     },
     DataScheme = "http",
     DataPathPrefix = "/tesla/",
     DataHost = "exrin.net")]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
     Categories = new[]
     {
        Android.Content.Intent.CategoryDefault,
        Android.Content.Intent.CategoryBrowsable
     },
     DataScheme = "tesla")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            Exrin.Framework.App.Init(new PlatformOptions() { Platform = Device.OS.ToString() });

            AndroidAppLinks.Init(this);
            
            var action = Intent?.Action;
            var data = Intent?.Data;
            
            LoadApplication(new App(new Bootstrapper()));

        }
    }
}

