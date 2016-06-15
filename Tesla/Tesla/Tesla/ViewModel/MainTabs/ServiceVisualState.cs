using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Model;

namespace Tesla.ViewModel.MainTabs
{
	public class ServiceVisualState : VisualState
	{
		public ServiceVisualState(IBaseModel model) : base(model) { }

		public IList<Booking> Bookings {
			get {
				return Get<IList<Booking>>();
			}
			set { Set(value); }
		}

		public override void Init()
		{
			Task.Run(async () =>
			{
				Bookings = await ServiceModel.GetBookings();
			});
		}

		private IServiceModel ServiceModel
		{
			get
			{
				return base.Model as IServiceModel;
			}
		}

	}
}
