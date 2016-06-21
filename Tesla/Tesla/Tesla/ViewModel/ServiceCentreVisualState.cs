using Exrin.Framework;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Model;

namespace Tesla.ViewModel
{
    public class ServiceCentreVisualState : VisualState
    {
        public ServiceCentreVisualState(IServiceModel model) : base(model) { }

        public ServiceCentre ServiceCentre
        {
            get { return Get<ServiceCentre>(); }
            set { Set(value); }
        }

    }
}
