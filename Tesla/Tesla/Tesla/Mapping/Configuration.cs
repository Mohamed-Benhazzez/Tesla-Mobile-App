using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaService.MappingProfile;

namespace Tesla.Mapping
{
	public class Configuration
	{

		public static IMapper GetMapper()
		{
			var mapperConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new DatabaseMapping());
			});

			return mapperConfiguration.CreateMapper();
		}


	}
}
