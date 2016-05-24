using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel.MainTabs
{
	public class ClimateVisualState : VisualState
	{
		public ClimateVisualState(IBaseModel model) : base(model) { }

		public override void Init()
		{
			Task.Run(async () =>
			{
				Temperature = await ClimateModel.GetTemperature();
			});
		}

		
		private IClimateModel ClimateModel
		{
			get
			{
				return base.Model as IClimateModel;
			}
		}

		public double Temperature
		{
			get { return Get<double>(); }
			set { Set(value); }
		}
	}
}
