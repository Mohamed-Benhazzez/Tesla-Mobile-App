using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Definition.ViewLocator;
using Tesla.Proxy;
using Tesla.View.MainTabs;
using Tesla.ViewModel;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
    public class ClimateStack : BaseStack
    {
        public ClimateStack(IViewService viewService)
               : base(new NavigationProxy(new NavigationPage() { Title = "Climate" }), viewService, Stacks.Climate)
        {
            ShowNavigationBar = false;
        }

        protected override void Map()
        {
            base.NavigationMap(nameof(Climate.Main), typeof(ClimateView), typeof(ClimateViewModel));
            base.NavigationMap(nameof(Climate.ClimateTwo), typeof(ClimateTwoView), typeof(ClimateViewModel));
        }

        public override string NavigationStartKey
        {
            get
            {
                return nameof(Climate.Main);
            }
        }
    }
}
