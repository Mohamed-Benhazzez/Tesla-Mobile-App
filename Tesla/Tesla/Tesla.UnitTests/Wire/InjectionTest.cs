using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Wire;
using Xunit;

namespace Tesla.Tests.Wire
{
    public class InjectionTest
    {
		

		//public Injection GetInjection()
		//{
		//	var mock = new Moq.Mock<ContainerBuilder>();

		//	mock.Setup(x=>x.RegisterInstance<IInjection>(this))

		//	return new Injection();
		//}

		//[Fact]
		//public void Init()
		//{

		//	//_builder.RegisterInstance<IInjection>(this).SingleInstance();
		//}
		//public void Complete()
		//{
		//	//Container = _builder.Build();
		//}
		//private void Register<T>(IRegistrationBuilder<T, IConcreteActivatorData, SingleRegistrationStyle> register, InstanceType type)
		//{
		//	switch (type)
		//	{
		//		case InstanceType.EachResolve:
		//			register.InstancePerDependency();
		//			break;
		//		case InstanceType.SingleInstance:
		//			register.SingleInstance();
		//			break;
		//		default:
		//			register.InstancePerDependency();
		//			break;
		//	}
		//}
		//public void Register<T>(InstanceType type) where T : class
		//{
		//	Register(_builder.RegisterType<T>(), type);
		//	_registered.Add(typeof(T));
		//}

		//public void RegisterInterface<I, T>(InstanceType type) where T : class, I
		//									 where I : class
		//{
		//	Register(_builder.RegisterType<T>().As<I>(), type);
		//	_registered.Add(typeof(I));
		//}

		//public void RegisterInstance<I, T>(T instance) where T : class, I
		//									 where I : class
		//{
		//	_builder.RegisterInstance<T>(instance).As<I>().SingleInstance();
		//	_registered.Add(typeof(I));
		//}


		//public T Get<T>() where T : class
		//{
		//	return Container.Resolve<T>();
		//}

		//public object Get(Type type)
		//{
		//	return Container.Resolve(type);
		//}

		//public bool IsRegistered<T>()
		//{
		//	return _registered.Contains(typeof(T));
		//}


	}
}
