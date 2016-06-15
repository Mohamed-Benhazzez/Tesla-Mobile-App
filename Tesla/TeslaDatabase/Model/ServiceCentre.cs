using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDatabase.Model
{
	public class ServiceCentre
	{
		[PrimaryKey]
		public string Id { get; set; }

		public string Name { get; set; }
	}
}
