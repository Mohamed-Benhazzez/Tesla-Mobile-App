using Exrin.Abstraction;
using System.Collections.Generic;
using System.Reflection;
using Tesla.Mapping;
using Tesla.Proxy;
using TeslaDatabase;
using TeslaDefinition.Interfaces.Database;
using Xamarin.Forms;

namespace Tesla
{
    public class Bootstrapper : Exrin.Framework.Bootstrapper
    {
        private static Bootstrapper _instance = null;

        public static Bootstrapper GetInstance(IPlatformBootstrapper platformBootstrapper)
        {
            if (_instance == null)
                _instance = new Bootstrapper(platformBootstrapper);

            return _instance;
        }

        private Bootstrapper(IPlatformBootstrapper platformBootstrapper) : base(new InjectionProxy(), (newView) =>
        {
            Application.Current.MainPage = newView as Page;
        })
        {
            platformBootstrapper?.Register(_injection);
        }

        protected override void InitCustom()
        {
            base.InitCustom();

            _injection.RegisterInstance(Configuration.GetMapper());

            _injection.RegisterInterface<IDatabase, Database>(InstanceType.SingleInstance);
        }

        // Any interface that implements IBaseModel will be loaded in InitModels() with its concrete implementation
        // Override InitModels() to define yourself

        // Any interface that implements IStack will be loaded in the InitStacks().
        // Override InitStacks() and use RegisterStack<T>() to register stacks manually

        protected override void InitServices()
        {
            RegisterTypeAssembly(typeof(IService), new AssemblyName(nameof(TeslaService)));
            base.InitServices();
        }

        protected override void StartInsights(IList<IInsightsProvider> providers)
        {
            providers = new List<IInsightsProvider>();
            providers.Add(new InsightProvider());

            base.StartInsights(providers);
        }
    }
}
