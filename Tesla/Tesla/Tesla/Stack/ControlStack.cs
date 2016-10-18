namespace Tesla.Stack
{
    using Exrin.Abstraction;
    using Exrin.Framework;
    using Proxy;
    using View.MainTabs;
    using ViewModel;
    using TeslaDefinition;
    using Xamarin.Forms;

    public class ControlStack : BaseStack
    {
        public ControlStack(IViewService viewService)
               : base(new NavigationProxy(new NavigationPage() { Title = "Control" }), viewService, Stacks.Control)
        {
            ShowNavigationBar = false;
        }

        protected override void Map()
        {
            base.NavigationMap<ControlView, ControlViewModel>(nameof(Definition.ViewLocator.Control.Main));
            base.NavigationMap<ControlTwoView, ControlViewModel>(nameof(Definition.ViewLocator.Control.ControlTwo));
        }

        public override string NavigationStartKey
        {
            get
            {
                return nameof(Definition.ViewLocator.Control.Main);
            }
        }
    }
}
