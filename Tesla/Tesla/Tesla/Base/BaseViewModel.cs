using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Base
{
    public class BaseViewModel : IViewModel
    {
        protected IExecution Execution { get; set; }

        public BaseViewModel()
        {
            Execution = new Execution()
            {
                HandleTimeout = timeoutHandle,
                NotifyOfActivity = notifyActivity,
                NotifyActivityFinished = notifyActivityFinished,
                HandleResult = completed
            };
        }



        public Task OnNavigated(object args)
        {
            return Task.FromResult(0);
        }
    }
}
