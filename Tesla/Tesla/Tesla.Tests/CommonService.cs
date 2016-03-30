using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Tests
{
    public class CommonService
    {
        public static IDisplayService DisplayService
        {
            get
            {
                return new DisplayService();
            }
        }

        public static IErrorHandlingService ErrorHandlingService
        {
            get
            {
                return new ErrorHandlingService();
            }
        }
    }
}
