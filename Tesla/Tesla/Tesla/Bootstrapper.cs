using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla
{
    public class Bootstrapper
    {
        private static AsyncLock _lock = new AsyncLock();
        private IDictionary<StackEnum, IStack> _stacks = null;
        private StackEnum? _currentStack = null;

        public Bootstrapper()
        {

            InitServices();

            InitStacks();

        }

        private void RegisterService<I, T>()
        {

        }

        /// <summary>
        /// Will initialize the basic navigation and display services
        /// </summary>
        private void InitServices()
        {
            RegisterService<IPageService, PageService>();
            RegisterService<INavigationService, NavigationService>();
            RegisterService<IDisplayService, DisplayService>();            
        }


        private void InitStacks()
        {
            RegisterService<AuthenticationStack>();
            RegisterOnce<MainStack>();

            _stacks = new Dictionary<StackEnum, IStack>();
            _stacks.Add(StackEnum.Authentication, ServiceLocator.Current.GetInstance<AuthenticationStack>());
            _stacks.Add(StackEnum.Main, ServiceLocator.Current.GetInstance<MainStack>());
        }

    }
}
