using Android.App;
using Android.OS;
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
            Exrin.Framework.App.Init();

            AndroidAppLinks.Init(this);

            var data = Intent?.Data;

            LoadApplication(new App(new Bootstrapper()));

        }
    }
}

