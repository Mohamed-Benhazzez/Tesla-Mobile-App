namespace Tesla.ViewContainer
{
    using TeslaDefinition.Enums;
    using Exrin.Abstraction;
    using Stack;

    public class AuthenticationViewContainer : Exrin.Framework.ViewContainer, ISingleContainer
    {

        public AuthenticationViewContainer(AuthenticationStack stack) 
            : base(ViewContainers.Authentication.ToString(), stack.Container.View)
        {
            Stack = stack;

        }

        public IStack Stack { get; set; }

    }
}
