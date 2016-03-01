using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tesla
{
    public static class Injection
    {

        public static void Register<T>() where T : class
        {
            DependencyService.Register<T>();
        }

        public static void RegisterService<I, T>() where T : class, I
                                             where I : class
        {
            DependencyService.Register<I, T>();
        }

        public static T Get<T>() where T: class
        {
            return DependencyService.Get<T>();
        }

    }
}
