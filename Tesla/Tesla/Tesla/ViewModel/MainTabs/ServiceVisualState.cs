using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Model;
using Xamarin.Forms;

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


        public static AppLinkEntry GetAppLink(ServiceCentre centre)
        {
            var url = $"http://exrin.net/servicecentre/{centre.Id.ToString()}";

            var entry = new AppLinkEntry
            {
                Title = "Service Centre",
                Description = centre.Name,
                AppLinkUri = new Uri(url, UriKind.RelativeOrAbsolute),
                IsLinkActive = true
            };

            if (Device.OS == TargetPlatform.iOS)
                entry.Thumbnail = ImageSource.FromFile("logo.png");

            entry.KeyValues.Add("contentType", "Service");
            entry.KeyValues.Add("appName", "Tesla");
            entry.KeyValues.Add("companyName", "Tesla");

            return entry;
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
