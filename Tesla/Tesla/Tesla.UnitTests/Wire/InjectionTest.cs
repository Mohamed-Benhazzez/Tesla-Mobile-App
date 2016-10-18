using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Proxy;
using Xunit;

namespace Tesla.Tests.Wire
{
	public class InjectionTest
	{


		public InjectionProxy GetInjection()
		{
			return new InjectionProxy();
		}

		[Fact]
		public void InitAndComplete()
		{
			var injection = GetInjection();
			injection.Init(); // Call Init - should register itself
			injection.Complete();
			var instance = injection.Get<IInjectionProxy>();

			Assert.Equal(injection, instance);
		}

		[Fact]
		public void RegisterInstance()
		{
			var injection = GetInjection();
			injection.Init();

			injection.RegisterInstance<ITestClass, TestClass>(new TestClass());

			injection.Complete();

			var test = injection.Get<ITestClass>();

			Assert.NotNull(test);
		}

		[Fact]
		public void RegisterInterface()
		{
			var injection = GetInjection();
			injection.Init();

			injection.RegisterInterface<ITestClass, TestClass>(InstanceType.SingleInstance);

			injection.Complete();

			var test = injection.Get<ITestClass>();

			Assert.NotNull(test);
		}
		
		[Fact]
		public void IsRegistered()
		{
			var injection = GetInjection();
			injection.Init();

			injection.RegisterInterface<ITestClass, TestClass>(InstanceType.SingleInstance);

			injection.Complete();

			Assert.Equal(true, injection.IsRegistered<ITestClass>());

		}


	}

	public class TestClass: ITestClass
	{

	}

	public interface ITestClass
	{

	}
	
}
