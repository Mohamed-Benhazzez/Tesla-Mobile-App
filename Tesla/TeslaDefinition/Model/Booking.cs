using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Model
{
	public class Booking
	{
		public string Id { get; set; }
		public DateTime BookedUtc { get; set; }
		public string ServiceCentreId { get; set; }
	}
}
