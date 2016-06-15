using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Model;

namespace TeslaService.MappingProfile
{
	public class DatabaseMapping : Profile
	{
		protected override void Configure()
		{
			CreateMap<TeslaDatabase.Model.Booking, Booking>().ReverseMap();
			CreateMap<TeslaDatabase.Model.ServiceCentre, ServiceCentre>().ReverseMap();
		}
	}

}
