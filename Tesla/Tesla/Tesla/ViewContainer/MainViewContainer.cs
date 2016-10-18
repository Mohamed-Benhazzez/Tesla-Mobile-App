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
            var tabbed = new TabbedView(new Xamarin.Forms.TabbedPage());
            View = tabbed.View;

            foreach (var child in Children)
            {
                tabbed.Children.Add(child.Proxy.View);
                child.StartNavigation(child.NavigationStartKey); // Needs to initialize on tabbed page to start with.
            }
        }

        public IList<IStack> Children { get; set; }

    }
}
