using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition;
using TeslaDefinition.Interfaces;

namespace Tesla.Base
{
    public class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        protected IExecution Execution { get; set; }

        private IDisplayService _displayService = null;
        private INavigationService _navigationService = null;
        private IErrorHandlingService _errorHandlingService = null;
        private IStackRunner _stackRunner = null;

        public BaseViewModel(IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner)
        {

            _displayService = displayService;
            _navigationService = navigationService;
            _errorHandlingService = errorHandlingService;
            _stackRunner = stackRunner;

            Execution = new Execution()
            {
                HandleTimeout = TimeoutHandle,
                NotifyOfActivity = NotifyActivity,
                NotifyActivityFinished = NotifyActivityFinished,
                HandleResult = HandleResult
            };
        }
        
        private Func<Task> TimeoutHandle
        {
            get
            {
                return async () =>
                {
                    await _displayService.ShowDialog("Timeout Occurred");
                };
            }
        }

        private Func<Task> NotifyActivity
        {
            get
            {
                return () =>
                {

                    IsBusy = true;

                    return Task.FromResult(0);

                };
            }
        }


        private Func<Task> NotifyActivityFinished
        {
            get
            {
                return () =>
                {
                    IsBusy = false;

                    return Task.FromResult(0);
                };
            }
        }

        private Func<IResult, Task> HandleResult
        {
            get
            {
                return async (result) =>
                {

                    if (result == null)
                        return;

                    // TODO: could have default added in Exrin
                    switch (result.ResultAction)
                    {
                        case ResultType.Navigation:
                            {
                                var args = result.Arguments as NavigationArgs;

                                // Determine Stack Change
                                _stackRunner.Run((Stacks)args.StackType);
                                                                
                                // Determine Page Load
                                await _navigationService.Navigate(Convert.ToString(args.PageIndicator), args.Parameter);
                                
                                break;
                            }
                        case ResultType.Error:
                            await _errorHandlingService.ReportError(result.Arguments as Exception);
                            break;

                        case ResultType.Display:
                            await _displayService.ShowDialog((result.Arguments as DisplayArgs).Message);
                            break;                           
                    }

                };
            }
        }

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged(); } }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        
        public virtual Task OnNavigated(object args)
        {
            return Task.FromResult(0);
        }

        public virtual Task OnBackNavigated(object args)
        {
            return Task.FromResult(0);
        }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        public virtual void OnPopped() { }
    }
}
