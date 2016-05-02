using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.View;
using Tesla.Definition.ViewLocator;
using Tesla.View.MainTabs;
using Tesla.ViewModel;
using Tesla.Wire;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
    public class MainStack: BaseStack
    {
        private IViewService _pageService = null;
        public MainStack(INavigationService navigationService, IViewService pageService)
               : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Main)
        {
            _pageService = pageService;
            ShowNavigationBar = false;
        }
        
        protected override void Map()
        {
            _navigationService.Map(nameof(Main.Main), typeof(MainView), typeof(MainViewModel));
            _navigationService.Map(string.Empty, typeof(ControlView), typeof(ControlViewModel));
            _navigationService.Map(string.Empty, typeof(ClimateView), typeof(ClimateViewModel));
        }

        protected override string NavigationStartKey
        {
            get
            {
                return nameof(Main.Main);
            }
        }

    }
}
