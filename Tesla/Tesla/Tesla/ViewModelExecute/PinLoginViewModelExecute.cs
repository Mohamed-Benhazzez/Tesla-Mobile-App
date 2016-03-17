using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.ViewModelOperation;

namespace Tesla.ViewModelExecute
{
    public class PinLoginViewModelExecute : IViewModelExecute
    {

        public PinLoginViewModelExecute()
        {
            Operations.Add(new PinLoginOperation()); // Hidden in a constructor, this implementation looks off
        }

        public List<IOperation> Operations { get; private set; } = new List<IOperation>();

        public int TimeoutMilliseconds { get; private set; } = 10000;
    }
}
