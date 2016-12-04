using Exrin.Abstraction;
using Exrin.Framework;
using System.Collections.Generic;
using Tesla.Base;
using Tesla.ViewModel.MainTabs;
using TeslaDefinition.Enums;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
	public class ClimateViewModel : BaseViewModel
    {
		private readonly IClimateModel _model = null;
        private readonly IExrinContainer _container;
        public ClimateViewModel(IAuthModel authModel, IClimateModel model, IExrinContainer exrinContainer):
            base (authModel, exrinContainer, new ClimateVisualState(model))
        {
			_model = model;
            _container = exrinContainer;
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
					return Execution.ViewModelExecute(new TemperatureOperation(Model, Temperature.Up));
				});
			}
		}

        public IRelayCommand NextCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new NextOperation());
                });
            }
        }

        public IRelayCommand DownCommand
		{
			get
			{
				return GetCommand(() =>
				{
					return Execution.ViewModelExecute(new TemperatureOperation(Model, Temperature.Down));
				});
			}
		}


	}
}
