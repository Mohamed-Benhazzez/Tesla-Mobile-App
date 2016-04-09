using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.Windows.Input;
using Exrin.Abstraction;
using Exrin.Framework;

namespace Tesla.Control
{
    public partial class StatusBarLabel : Grid
    {

        public StatusBarLabel()
        {
            InitializeComponent();


        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(StatusBarLabel), (object)null, propertyChanged: (b, o, n) =>
        {
            var grid = b as StatusBarLabel;

            grid.MainLabel.GestureRecognizers.Clear();
            var cmd = n as IRelayCommand;


            Action action = () =>
            {
                grid.InProgress(); // Start Bar
                cmd.FinishedCallback = () =>
                {
                    //TODO: not cancelling
                    ThreadHelper.RunOnUIThread(() => ViewExtensions.CancelAnimations(grid));
                };
                cmd.Execute(null);



            };
            var run = new RunCommand(action);

            grid.MainLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = run });
        });


        private class RunCommand : ICommand
        {
            private Action _action = null;
            public RunCommand(Action action)
            {
                _action = action;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _action();

            }
        }

        private ICommand RelayCommand { get; set; }

        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(CommandProperty);
            }
            set
            {
                this.SetValue(CommandProperty, (object)value);
            }
        }

        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(StatusBarLabel), defaultValue: string.Empty, propertyChanged: (b, o, n) =>
        {
            // One-Way Binding
            var statusBarLabel = b as StatusBarLabel;
            statusBarLabel.MainLabel.Text = n as string;
        });

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(StatusBarLabel), defaultValue: false, propertyChanged: OnIsRunningChanged);

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static BindableProperty IsSuccessfulProperty = BindableProperty.Create(nameof(IsSuccessful), typeof(bool), typeof(StatusBarLabel), defaultValue: false);

        public bool IsSuccessful
        {
            get { return (bool)GetValue(IsSuccessfulProperty); }
            set { SetValue(IsSuccessfulProperty, value); }
        }

        public void InProgress()
        {
            var grid = this as StatusBarLabel;
            var newValue = true;

            if (newValue == true)
            {
                grid.StatusBar.IsVisible = true;
                grid.StatusBar.Opacity = 1;
                grid.StatusBar.HorizontalOptions = LayoutOptions.Start;
                var jumpCount = grid.Width / grid.Timeout;

                var animation = new Animation(callback: d => grid.StatusBar.WidthRequest = d,
                                      start: 0,
                                      end: grid.Width,
                                      easing: Easing.Linear);

                animation.Commit(grid, "Move", rate: Convert.ToUInt32(jumpCount), length: Convert.ToUInt32(Timeout), finished: (length, result) =>
                {
                    grid.StatusBar.BackgroundColor = Color.Red;

                    var anim = new Animation(callback: d => grid.StatusBar.Opacity = d, start: 1, end: 0, easing: Easing.Linear);
                    anim.Commit(grid, "Fade", rate: 10, length: 3000, finished: (l, r) => { grid.StatusBar.IsVisible = false; });
                });

            }
            else
            {
                ViewExtensions.CancelAnimations(grid);
                // If success - turn green, then fade

                // if fail - turn red, then fade
            }
        }

        public int Timeout = 10000;
        private static void OnIsRunningChanged(BindableObject bindable, object oldvalue, object newvalue)
        {

        }



        // bottom bar

    }
}
