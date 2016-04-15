using Autofac;
using Autofac.Builder;
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
       
        private static IList<Type> _registered = new List<Type>();

        public void Init()
        {
            _builder = new ContainerBuilder();
            
            _builder.RegisterInstance<IInjection>(this).SingleInstance();
        }
        public void Complete()
        {
            Container = _builder.Build();
        }
        private void Register<T>(IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> register, InstanceType type)
        {
            switch (type)
            {
                case InstanceType.EachResolve:
                    register.InstancePerDependency();
                    break;
                case InstanceType.SingleInstance:
                    register.SingleInstance();
                    break;
                default:
                    register.InstancePerDependency();
                    break;
            }
        }
        public void Register<T>(InstanceType type) where T : class
        {
            Register(_builder.RegisterType<T>(), type);
            _registered.Add(typeof(T));
        }

        public void RegisterInterface<I, T>(InstanceType type) where T : class, I
                                             where I : class
        {
            Register(_builder.RegisterType<T>().As<I>(), type);
            _registered.Add(typeof(I));
        }
        
        public T Get<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        public object Get(Type type)
        {
            return Container.Resolve(type);
        }

        public bool IsRegistered<T>()
        {          
            return _registered.Contains(typeof(T));
        }
    }
}
