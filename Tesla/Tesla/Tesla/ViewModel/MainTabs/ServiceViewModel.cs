using Exrin.Abstraction;
using Exrin.Framework;
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

        public IRelayCommand ViewBookingCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new ViewBookingViewModelExecute(Model));
                });
            }
        }

    }
}
