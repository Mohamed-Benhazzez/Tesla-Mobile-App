using Exrin.Abstraction;
using System.Collections.Generic;
using System.Reflection;
using Tesla.Model;
using Tesla.Stack;
using Tesla.Wire;
using TeslaDefinition;
using TeslaDefinition.Interfaces.Model;
using Xamarin.Forms;

namespace Tesla
{
    public class Bootstrapper : Exrin.Framework.Bootstrapper
    {
        public Bootstrapper() : base(new Injection(), (newView) => { Application.Current.MainPage = newView as Page; }) { }

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
