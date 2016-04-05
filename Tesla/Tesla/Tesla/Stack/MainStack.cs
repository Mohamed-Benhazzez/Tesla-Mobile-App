using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.View;
using Tesla.View.MainTabs;
using Tesla.ViewModel;
using Tesla.Wire;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
    public class MainStack: BaseStack
    {
        private IPageService _pageService = null;
        public MainStack(INavigationService navigationService, IPageService pageService)
               : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Main)
        {
            _pageService = pageService;
            ShowNavigationBar = false;
        }
        
        protected override void MapPages()
        {
            _navigationService.Map(nameof(PageLocator.Main.Main), typeof(MainPage));
        }

        protected override void MapViewModels()
        {
            _pageService.Map(typeof(MainPage), typeof(MainViewModel));
            _pageService.Map(typeof(ControlPage), typeof(ControlViewModel));
            _pageService.Map(typeof(ClimatePage), typeof(ClimateViewModel));

        }

        protected override string NavigationStartPageKey
        {
            get
            {
                return nameof(PageLocator.Main.Main);
            }
        }

    }
}
