using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Stack;
using TeslaDefinition;
using TeslaDefinition.Interfaces;
using Xamarin.Forms;

namespace Tesla
{
    public class StackRunner: IStackRunner
    {
        private readonly IDictionary<Stacks, IStack> _stacks = new Dictionary<Stacks, IStack>();
        private Stacks? _currentStack = null;
        private readonly INavigationService _navigationService;
        private readonly IDisplayService _displayService;

        public StackRunner(INavigationService navigationService, IDisplayService displayService)
        {
            _navigationService = navigationService;
            _displayService = displayService;

            InitStacks();
        }

        private void InitStacks()
        {
            Injection.Register<AuthenticationStack>();
            Injection.Register<MainStack>();

            _stacks.Add(Stacks.Authentication, Injection.Get<AuthenticationStack>());
            _stacks.Add(Stacks.Main, Injection.Get<MainStack>());
        }

        public void Run(Stacks stackChoice)
        {
            // Don't change to the same stack
            if (_currentStack == stackChoice)
                return;

            var stack = _stacks[stackChoice];

            _currentStack = stackChoice;

            // Switch over services
            _navigationService.Init(stack.Container);
            _displayService.Init(stack.Container);

            Application.Current.MainPage = stack.Container.Page as Page;
        }
    }
}
