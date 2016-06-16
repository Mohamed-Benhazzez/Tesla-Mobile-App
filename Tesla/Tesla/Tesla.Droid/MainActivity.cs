using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Tesla.Droid
{
    [Activity(Label = "Tesla", MainLauncher = true, Theme = "@style/main", Icon = "@drawable/icon")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            Exrin.Framework.App.Init();
            LoadApplication(new App(new Bootstrapper()));
        }
    }
}

