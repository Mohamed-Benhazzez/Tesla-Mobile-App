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
        public AuthenticationStack(INavigationService navigationService)
            : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Authentication)
        {
            ShowNavigationBar = false;
        }

        protected override void Map()
        {
            base.NavigationMap(nameof(Authentication.Pin), typeof(PinView), typeof(PinViewModel));
        }

        protected override string NavigationStartKey
        {
            get
            {
                return nameof(Authentication.Pin);
            }
        }
    }
}
