namespace Tesla.Stack
{
    using Exrin.Abstraction;
    using Exrin.Framework;
    using Definition.ViewLocator;
    using Proxy;
    using View;
    using ViewModel;
    using TeslaDefinition;
    using Xamarin.Forms;

    public class AuthenticationStack : BaseStack
    {
        public AuthenticationStack(IViewService viewService)
            : base(new NavigationProxy(new NavigationPage()), viewService, Stacks.Authentication)
        {
            ShowNavigationBar = true;
        }

        protected override void Map()
        {
            base.NavigationMap<PinView, PinViewModel>(nameof(Authentication.Pin));
            base.NavigationMap<UWPPinView, PinViewModel>(nameof(Authentication.Pin), new MapOptions() { Platform = Device.OS.ToString() });
        }

        public override string NavigationStartKey
        {
            get
            {
                return nameof(Authentication.Pin);
            }
        }
    }
}
