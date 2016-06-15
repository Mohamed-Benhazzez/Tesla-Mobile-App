using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
	public class ServiceViewModel : BaseViewModel
	{

		public ServiceViewModel(IAuthModel authModel, IServiceModel model, IExrinContainer exrinContainer) :
            base(authModel, exrinContainer, new ServiceVisualState(model))
        {
			Model = model;
		}

		// Model
		public IServiceModel Model { get; set; }

		

	}
}
