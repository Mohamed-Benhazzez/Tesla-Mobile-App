using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Definition.ViewLocator;
using Tesla.Proxy;
using Tesla.View.MainTabs;
using Tesla.ViewModel;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
    public class ControlStack : BaseStack
    {
        public ControlStack(INavigationService navigationService)
               : base(navigationService, new NavigationContainer(new NavigationPage() { Title = "Control" }), Stacks.Control)
        {
            ShowNavigationBar = false;
        }

        protected override void Map()
        {
            base.NavigationMap(nameof(Definition.ViewLocator.Control.Main), typeof(ControlView), typeof(ControlViewModel));

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
