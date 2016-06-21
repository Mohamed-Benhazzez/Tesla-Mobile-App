using Exrin.Abstraction;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class ServiceCentreViewModel : BaseViewModel
    {
        public ServiceCentreViewModel(IAuthModel model, IServiceModel serviceModel, IExrinContainer exrinContainer) :
            base(model, exrinContainer, new ServiceCentreVisualState(serviceModel))
        { }
    }
}
