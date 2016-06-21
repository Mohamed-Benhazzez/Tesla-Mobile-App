using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Database;
using TeslaDefinition.Interfaces.Service;
using TeslaDefinition.Model;

namespace TeslaService
{
    public class ServiceService : IServiceService
    {
        IDatabase _database = null;
        IMapper _mapper = null;

        public ServiceService(IDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;

            // TEMP: Just to test adding a booking
            SaveBooking(new Booking() { BookedUtc = DateTime.UtcNow, ServiceCentreId = "", Id="1234" }, false);
        }

        public async Task<IList<Booking>> GetBookings()
        {
            var result = await _database.GetAll<TeslaDatabase.Model.Booking>();

            return _mapper.Map<IList<Booking>>(result);
        }

        public async Task<IList<ServiceCentre>> GetServiceCentres()
        {
            var result = await _database.GetAll<TeslaDatabase.Model.ServiceCentre>();

            return _mapper.Map<IList<ServiceCentre>>(result);
        }

        public async Task SaveBooking(Booking booking, bool newId = true)
        {

            var item = _mapper.Map<TeslaDatabase.Model.Booking>(booking);

            if (String.IsNullOrEmpty(item.Id))
            {
                if (newId)
                    item.Id = Guid.NewGuid().ToString();
                await _database.Insert(item);
            }
            else
            {
                await _database.Update(item);
            }
        }
    }
}
