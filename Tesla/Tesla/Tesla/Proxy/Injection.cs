namespace Tesla.Proxy
{
    using Autofac;
    using Autofac.Builder;
    using Exrin.Abstraction;
    using System;
    using System.Collections.Generic;

    public class Injection : IInjection
    {
        private static ContainerBuilder _builder = null;
        private static IContainer Container { get; set; } = null;
        private static IList<Type> _registered = new List<Type>();

        public void Init()
        {
            if (_builder == null)
            {
                _builder = new ContainerBuilder();

                _builder.RegisterInstance<IInjection>(this).SingleInstance();
            }
        }
        public void Complete()
        {
            if (Container == null)
                Container = _builder.Build();
        }
        private void Register<T>(IRegistrationBuilder<T, IConcreteActivatorData, SingleRegistrationStyle> register, InstanceType type)
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

        public void RegisterInstance<I, T>(T instance) where T : class, I
                                             where I : class
        {
            _builder.RegisterInstance<T>(instance).As<I>().SingleInstance();
            _registered.Add(typeof(I));
        }

        public void RegisterInstance<I>(I instance) where I : class
        {
            _builder.RegisterInstance(instance).As<I>().SingleInstance();
            _registered.Add(typeof(I));
        }


        public T Get<T>(bool optional = false) where T : class
        {
            if (Container == null)
                throw new NullReferenceException($"{nameof(Container)} is null. Have you called {nameof(IInjection)}.{nameof(Init)}() and {nameof(IInjection)}.{nameof(Complete)}()?");

            if (optional)
                if (!Container.IsRegistered<T>())
                    return null;

            return Container.Resolve<T>();
        }

        public object Get(Type type)
        {
            if (Container == null)
                throw new NullReferenceException($"{nameof(Container)} is null. Have you called {nameof(IInjection)}.{nameof(Init)}() and {nameof(IInjection)}.{nameof(Complete)}()?");
            return Container.Resolve(type);
        }

        public bool IsRegistered<T>()
        {
            return _registered.Contains(typeof(T));
        }

    }
}
