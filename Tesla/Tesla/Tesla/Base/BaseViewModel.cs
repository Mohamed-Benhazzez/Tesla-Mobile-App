using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Base
{
    public class BaseViewModel : IViewModel
    {
        public Task OnNavigated(object args)
        {
            return Task.FromResult(0);
        }
    }
}
