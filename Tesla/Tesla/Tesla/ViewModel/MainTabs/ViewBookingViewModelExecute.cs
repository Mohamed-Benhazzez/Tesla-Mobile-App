using Exrin.Framework;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Model;

namespace Tesla.ViewModel
{
    public class ViewBookingViewModelExecute : BaseViewModelExecute
    {
        public ViewBookingViewModelExecute(IServiceModel model)
        {
            TimeoutMilliseconds = 10000;
            Operations.Add(new ViewBookingOperation(model));
        }
    }

}
