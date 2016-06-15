using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
	public class BookingViewModel : BaseViewModel
	{
		public BookingViewModel(IAuthModel model, IServiceModel serviceModel, IExrinContainer exrinContainer) :
            base(model, exrinContainer, new BookingVisualState(serviceModel))
        {

		}
	}
}
