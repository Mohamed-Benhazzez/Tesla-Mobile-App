namespace Tesla.ViewContainer
{
    using Exrin.Abstraction;
    using Stack;
    using TeslaDefinition.Enums;

    public class MainViewContainer : Exrin.Framework.ViewContainer, ISingleContainer
    {

        public MainViewContainer(MainStack stack) : base(ViewContainers.Main.ToString(), stack.Container.View)
        {
            Stack = stack;
        }

        public IStack Stack { get; set; }

    }
}
