using Autofac;
using Autofac.Core;
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

        private static ContainerBuilder _builder = null;
        private static IContainer Container { get; set; } = null;

        public static void Init()
        {
            _builder = new ContainerBuilder();
        }

        public static void Complete()
        {
            Container = _builder.Build();
        }

        public static void Register<T>() where T : class
        {
            _builder.RegisterType<T>().SingleInstance();
        }

        public static void Register<I, T>() where T : class, I
                                             where I : class
        {
            _builder.RegisterType<T>().As<I>().SingleInstance();
        }

        /// <summary>
        /// Use CAUTION. Only designed for very limited use
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class
        {
            return Container.Resolve<T>();
        }

    }
}
