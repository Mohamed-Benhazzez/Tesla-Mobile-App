using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.View;
using Tesla.ViewModel;
using Tesla.Wire;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
    public class AuthenticationStack : BaseStack
    {
        IPageService _pageService = null;

        public AuthenticationStack(INavigationService navigationService, IPageService pageService)
            : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Authentication)
        {
            _pageService = pageService;
            ShowNavigationBar = false;
        }

        protected override void MapPages()
        {
            _navigationService.Map(nameof(PageLocator.Authentication.Pin), typeof(PinPage));
        }

        protected override void MapViewModels()
        {
            _pageService.Map(typeof(PinPage), typeof(PinViewModel));
        }

        protected override string NavigationStartPageKey
        {
            get
            {
                return nameof(PageLocator.Authentication.Pin);
            }
        }
    }
}
