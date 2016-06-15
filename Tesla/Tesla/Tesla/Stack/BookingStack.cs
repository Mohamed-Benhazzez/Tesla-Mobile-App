using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Definition.ViewLocator;
using Tesla.View;
using Tesla.ViewModel;
using Tesla.Wire;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla.Stack
{
	public class BookingStack : BaseStack
	{

		public BookingStack(INavigationService navigationService)
	  : base(navigationService, new NavigationContainer(new NavigationPage()), Stacks.Booking)
		{
			ShowNavigationBar = false;			
		}

		protected override void Map()
		{
			base.NavigationMap(nameof(Booking.Main), typeof(BookingView), typeof(BookingViewModel));
		}

		protected override string NavigationStartKey
		{
			get
			{
				return nameof(Booking.Main);
			}
		}
	}
}
