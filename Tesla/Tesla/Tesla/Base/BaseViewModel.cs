using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Base
{
    public class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        protected IExecution Execution { get; set; }

        public BaseViewModel()
        {
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
                    // TODO: could have default added in Exrin
                    switch (result.ResultAction)
                    {
                        case ResultType.Navigation:
                            await _navigationService.Navigate(result.Arguments as NavigationArgs);
                            break;
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

        // TODO: Look at putting this in Exrin but might lock VM and Models rather than leave it open
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        
        public Task OnNavigated(object args)
        {
            return Task.FromResult(0);
        }
    }
}
/