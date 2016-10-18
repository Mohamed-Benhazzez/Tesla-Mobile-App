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
            NativeView = mdp.View;
            Proxy = mdp;
            DetailStack = stack;
            MasterStack = bookingStack;     
        }

        public IStack DetailStack { get; set; }

        public IStack MasterStack { get; set; }

        public IMasterDetailProxy Proxy { get; set; }
    }
}
