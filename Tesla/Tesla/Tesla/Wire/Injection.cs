using Autofac;
using Autofac.Core;
using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tesla.Wire
{
    public class Injection: IInjection
    {

        private static ContainerBuilder _builder = null;
        private static IContainer Container { get; set; } = null;

        public void Init()
        {
            _builder = new ContainerBuilder();

            _builder.RegisterInstance<IInjection>(this).SingleInstance();
        }

        public void Complete()
        {
            Container = _builder.Build();
        }

        public void Register<T>() where T : class
        {
            _builder.RegisterType<T>().SingleInstance();
        }

        public void Register<I, T>() where T : class, I
                                             where I : class
        {
            _builder.RegisterType<T>().As<I>().SingleInstance();
        }
        
        public T Get<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        public object Get(Type type)
        {
            return Container.Resolve(type);
        }
    }
}
