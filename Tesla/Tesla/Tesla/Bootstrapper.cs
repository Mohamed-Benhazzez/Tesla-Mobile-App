using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Model;
using Tesla.Stack;
using Tesla.Wire;
using TeslaDefinition;
using TeslaDefinition.Interfaces;
using TeslaDefinition.Interfaces.Model;
using Xamarin.Forms;

namespace Tesla
{
    public class Bootstrapper : Exrin.Framework.Bootstrapper
    {
        public Bootstrapper() : base(new Injection(), (newPage) => { Application.Current.MainPage = newPage as Page; }) { }

        protected override void InitStacks()
        {          
            RegisterStack<AuthenticationStack>(Stacks.Authentication);
            RegisterStack<MainStack>(Stacks.Main);
        }

        protected override void InitModels()
        {
            _injection.Register<IPinModel, PinModel>();
            _injection.Register<IMainModel, MainModel>();
        }
    }
}
