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

        public static void Run(Stacks stackChoice)
        {
            var stack = _stacks[stackChoice];

            stack.Init(); 
            // Needs to switch current container in Dialog and Navigation Service
            // Or stack switching calls throughout app?

            Application.Current.MainPage = stack.Container.Page as Page;
        }
    }
}
