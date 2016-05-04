using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Base;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Enums;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
	public class ClimateViewModel : BaseViewModel
    {
		private readonly IClimateModel _model = null;
        public ClimateViewModel(IClimateModel model, IApplicationInsights applicationInsights, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner):
            base (applicationInsights, displayService, navigationService, errorHandlingService, stackRunner, new ClimateVisualState(model))
        {
			_model = model;
        }

		private IClimateModel Model
		{
			get
			{
				return _model;
			}
		}

		public IRelayCommand UpCommand
		{
			get
			{
				return GetCommand(() =>
				{
					return Execution.ViewModelExecute(new TemperatureViewModelExecute(Model, Temperature.Up));
				});
			}
		}

		public IRelayCommand DownCommand
		{
			get
			{
				return GetCommand(() =>
				{
					return Execution.ViewModelExecute(new TemperatureViewModelExecute(Model, Temperature.Down));
				});
			}
		}


	}
}
