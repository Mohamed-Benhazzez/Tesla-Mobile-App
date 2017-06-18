namespace Tesla.ViewContainer
{
	using System;
	using Exrin.Abstraction;
	using Proxy;
	using Stack;
	using TeslaDefinition.Enums;
	using Xamarin.Forms;

	public class AuthenticationViewContainer : Exrin.Framework.ViewContainer, IMasterDetailContainer
    {
		private readonly MasterDetailPage _page = new MasterDetailPage();

		public AuthenticationViewContainer(AuthenticationStack stack, BookingStack bookingStack) 
            : base(ViewContainers.Authentication.ToString())
        {
            var mdp = new MasterDetailProxy(_page);
            NativeView = mdp.View;
            Proxy = mdp;
            DetailStack = stack;
            MasterStack = bookingStack;     
        }

        public IStack DetailStack { get; set; }

        public IStack MasterStack { get; set; }

        public IMasterDetailProxy Proxy { get; set; }

		public bool IsPresented { get { return _page.IsPresented; } set { _page.IsPresented = value; } }

		public void SetStack(ContainerType type, object page)
		{
			switch (type)
			{
				case ContainerType.Detail:
					_page.Detail = page as Page;
					break;
				case ContainerType.Master:
					_page.Master = page as Page;
					break;
			}
		}
	}
}
