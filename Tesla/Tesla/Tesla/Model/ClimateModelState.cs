using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    public class ClimateModelState: ModelState, IClimateModelState
    {
		public ClimateModelState()
		{
			Temperature = 24;
		}

		public double Temperature { get { return Get<double>(); } set { Set(value); } }
	}
}
