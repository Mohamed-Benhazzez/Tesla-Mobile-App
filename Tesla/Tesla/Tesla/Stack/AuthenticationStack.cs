using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.View;
using Tesla.ViewModel;
using Tesla.Wire;
using TeslaDefinition;
using Xamarin.Forms;
using Tesla.Definition.ViewLocator;

namespace Tesla.Stack
{
    public class AuthenticationStack : BaseStack
    {
        public AuthenticationStack(INavigationService navigationService)
            : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Authentication)
        {
            ShowNavigationBar = false;
        }

        protected override void Map()
        {
            _navigationService.Map(nameof(Authentication.Pin), typeof(PinView), typeof(PinViewModel));
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
