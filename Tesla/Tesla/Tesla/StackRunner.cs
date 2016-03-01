using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Stack;
using TeslaDefinition;
using Xamarin.Forms;

namespace Tesla
{
    public static class StackRunner
    {
        private readonly static IDictionary<Stacks, IStack> _stacks = new Dictionary<Stacks, IStack>();
        private static Stacks? _currentStack = null;

        public static void Init()
        {
            InitStacks();
        }

        private static void InitStacks()
        {
            Injection.Register<AuthenticationStack>();
            Injection.Register<MainStack>();

            _stacks.Add(Stacks.Authentication, Injection.Get<AuthenticationStack>());
            _stacks.Add(Stacks.Main, Injection.Get<MainStack>());
        }

        public static void Run()
        {
            // Get MainPage and switch it

            // Application.Current.MainPage = 
        }
    }
}
