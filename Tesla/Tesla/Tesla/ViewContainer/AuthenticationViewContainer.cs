namespace Tesla.ViewContainer
{
    using Exrin.Abstraction;
    using Proxy;
    using Stack;
    using TeslaDefinition.Enums;

    public class AuthenticationViewContainer : Exrin.Framework.ViewContainer, IMasterDetailContainer
    {
        
        public AuthenticationViewContainer(AuthenticationStack stack, BookingStack bookingStack) 
            : base(ViewContainers.Authentication.ToString())
        {
            var mdp = new MasterDetailProxy(new Xamarin.Forms.MasterDetailPage());
            View = mdp.View;
            Proxy = mdp;
            Detail = stack;
            Master = bookingStack;     
        }

        public IStack Detail { get; set; }

        public IStack Master { get; set; }

        public IMasterDetailProxy Proxy { get; set; }
    }
}
