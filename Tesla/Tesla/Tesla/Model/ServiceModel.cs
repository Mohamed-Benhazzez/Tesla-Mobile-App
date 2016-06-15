using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exrin.Abstraction;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;
using TeslaDefinition.Model;

namespace Tesla.Model
{
	public class ServiceModel : BaseModel, IServiceModel
	{
		private IServiceService _serviceService = null;
		public ServiceModel(IExrinContainer exrinContainer, IServiceService serviceService, IAuthModel authModel)
            : base(exrinContainer, new ServiceModelState())
        {
			_serviceService = serviceService;
		}

		public async Task<IList<Booking>> GetBookings()
		{
			return await _serviceService.GetBookings();
		}

		public async Task<IList<ServiceCentre>> GetServiceCentres()
		{
			return await _serviceService.GetServiceCentres();
		}

		public async Task SaveBooking(Booking booking)
		{
			await _serviceService.SaveBooking(booking);
		}
	}
}
