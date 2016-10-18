using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Definition.ViewLocator;
using Tesla.Proxy;
using Tesla.View;
using Tesla.ViewModel;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
    public class BookingStack : BaseStack
	{

		public BookingStack(IViewService viewService)
	  : base(new NavigationProxy(new NavigationPage()), viewService, Stacks.Booking)
		{
			ShowNavigationBar = false;			
		}

		protected override void Map()
		{
			base.NavigationMap(nameof(Booking.BookingMain), typeof(BookingView), typeof(BookingViewModel));
		}

		public override string NavigationStartKey
		{
			get
			{
				return nameof(Booking.BookingMain);
			}
		}
	}
}
