using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.UWP.Platform;
using TeslaDatabase.Interfaces.Platform;

namespace Tesla.UWP
{
	public class Bootstrapper : IPlatformBootstrapper
	{
		public void Register(IInjection injection)
		{
			injection.RegisterInterface<IPlatformDatabase, Database>(InstanceType.SingleInstance);
		}
	}
}
