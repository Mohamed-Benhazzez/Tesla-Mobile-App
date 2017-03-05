namespace Tesla.ViewContainer
{
    using Exrin.Abstraction;
    using Proxy;
    using Stack;
    using System.Collections.Generic;
    using TeslaDefinition.Enums;

    public class MainViewContainer : Exrin.Framework.ViewContainer, ITabbedContainer
    {

        public MainViewContainer(ControlStack controlStack, ClimateStack climateStack)
            : base(ViewContainers.Main.ToString(), null)
        {
            Children = new List<IStack>() { controlStack, climateStack };
            var tabbedPage = new Xamarin.Forms.TabbedPage();
            var tabbed = new TabbedView(tabbedPage);
            NativeView = tabbed.View;

            foreach (var child in Children)
            {
                tabbed.Children.Add(child.Proxy.NativeView);
            }
        }


        public IList<IStack> Children { get; set; }

    }
}
