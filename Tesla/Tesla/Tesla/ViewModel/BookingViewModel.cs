using Exrin.Abstraction;
using Exrin.Framework;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Model;

namespace Tesla.ViewModel
{
    public class BookingViewModel : BaseViewModel
	{
        public BookingViewModel(IAuthModel model, IServiceModel serviceModel, IExrinContainer exrinContainer) :
            base(model, exrinContainer, new BookingVisualState(serviceModel))
        { }

        public override async Task OnNavigated(object args)
        {
            await base.OnNavigated(args);

            ((BookingVisualState)VisualState).Booking = (Booking)args;
        }

        public IRelayCommand CloseCommand
        {
            get
            {
                return GetCommand(() =>
                {
                    return Execution.ViewModelExecute(new CloseViewModelExecute());
                });
            }
        }
    }
}
