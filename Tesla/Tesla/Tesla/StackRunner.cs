using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Stack;
using TeslaDefinition;
using TeslaDefinition.Interfaces;
using Xamarin.Forms;

namespace Tesla
{
    public class StackRunner : IStackRunner
    {
        private readonly IDictionary<Stacks, IStack> _stacks = new Dictionary<Stacks, IStack>();
        private Stacks? _currentStack = null;
        private readonly INavigationService _navigationService;
        private readonly IDisplayService _displayService;
        private readonly IInjection _injection;

        public StackRunner(INavigationService navigationService, IDisplayService displayService, IInjection injection)
        {
            _navigationService = navigationService;
            _displayService = displayService;
            _injection = injection;

            InitStacks();
        }

        private void InitStacks()
        {
            _injection.Register<AuthenticationStack>();
            _injection.Register<MainStack>();

            _stacks.Add(Stacks.Authentication, _injection.Get<AuthenticationStack>());
            _stacks.Add(Stacks.Main, _injection.Get<MainStack>());
        }

        public void Run(Stacks stackChoice, object args = null)
        {
            // Don't change to the same stack
            if (_currentStack == stackChoice)
                return;

            var stack = _stacks[stackChoice];

            _currentStack = stackChoice;

            // Switch over services
            _navigationService.Init(stack.Container);
            _displayService.Init(stack.Container);

            if (stack.Status == StackStatus.Stopped)
                Task.Run(async () => await stack.StartNavigation(args));
            
            ThreadHelper.RunOnUIThread(() =>
             {
                 Application.Current.MainPage = stack.Container.Page as Page;
             });

        }
    }
}
