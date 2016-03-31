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
        public Bootstrapper() : base(new Injection(), (newPage) => { Application.Current.MainPage = newPage as Page; }) { }

        protected override void InitStacks()
        {          
            // TODO: convention - register in namespace (have defaults, can be overriden here)
            RegisterStack<AuthenticationStack>(Stacks.Authentication);
            RegisterStack<MainStack>(Stacks.Main);
        }

        protected override void InitModels()
        {
            // TODO: convention - register in namespace
            _injection.Register<IPinModel, PinModel>();
            _injection.Register<IMainModel, MainModel>();
            _injection.Register<IControlModel, ControlModel>();
            _injection.Register<IClimateModel, ClimateModel>();
        }
    }
}
