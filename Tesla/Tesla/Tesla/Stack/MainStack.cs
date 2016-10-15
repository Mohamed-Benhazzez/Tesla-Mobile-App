//using Exrin.Abstraction;
//using Exrin.Framework;
//using Tesla.Definition.ViewLocator;
//using Tesla.Proxy;
//using Tesla.View;
//using Tesla.View.MainTabs;
//using Tesla.ViewModel;
//using TeslaDefinition;
//using Xamarin.Forms;

// TEMPORARILY DISABLED WHILE TESTING THE ITabbedView

//namespace Tesla.Stack
//{
//    public class MainStack: BaseStack
//    {
//        private IViewService _pageService = null;
//        public MainStack(INavigationService navigationService, IViewService pageService)
//               : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Main)
//        {
//            _pageService = pageService;
//            ShowNavigationBar = false;
//        }
        
//        protected override void Map()
//        {
//			base.NavigationMap(nameof(Main.Main), typeof(MainView), typeof(MainViewModel));
//			base.NavigationMap(string.Empty, typeof(ControlView), typeof(ControlViewModel)); // No key mapping for views loaded in TabView
//			base.NavigationMap(string.Empty, typeof(ClimateView), typeof(ClimateViewModel));
//			base.NavigationMap(string.Empty, typeof(ServiceView), typeof(ServiceViewModel));			
//		}

//        protected override string NavigationStartKey
//        {
//            get
//            {
//                return nameof(Main.Main);
//            }
//        }

//    }
//}
