using Exrin.Framework;

namespace Tesla.ViewModel
{
    public class CloseViewModelExecute : BaseViewModelExecute
    {
        public CloseViewModelExecute()
        {
            TimeoutMilliseconds = 10000;
            Operations.Add(new CloseOperation());
        }
    }
}
