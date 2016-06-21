using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Model;

namespace TeslaDefinition.Interfaces.Service
{
	public interface IServiceService : IService
	{

		Task SaveBooking(Booking booking, bool newId = true);

		Task<IList<Booking>> GetBookings();

		Task<IList<ServiceCentre>> GetServiceCentres();

	}
}
