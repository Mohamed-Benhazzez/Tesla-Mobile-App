using Exrin.Framework;
using System;
using System.Windows.Input;
using Tesla.Gestures;
using Xamarin.Forms;

namespace Tesla.Control
{
    public class Keypad : Grid
    {
        public Keypad()
        {
            this.ColumnSpacing = 3;
            this.RowSpacing = 3;

            DefineGrid();

            DefineKeys();

            this.Padding = new Thickness(5);
        }

        private void DefineGrid()
        {
            var rows = 3;
            for (int i = 0; i < rows; i++)
                this.RowDefinitions.Add(new RowDefinition() { Height = 50 });

            var cols = 3;
            for (int i = 0; i < cols; i++)
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
        }

        private void DefineKeys()
        {

            var backgroundColor = Color.Black;
            var textColor = Color.White;

            for (int i = 0; i < 9; i++)
            {
                var label = new Label() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = backgroundColor, TextColor = textColor, Text = (i + 1).ToString(), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

                AttachGestures(label, i + 1);

                this.Children.Add(label, i - ((i / 3) * 3), i / 3);
            }

            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 0, 3);

            var zeroLabel = new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "0", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            AttachGestures(zeroLabel, 0);
            this.Children.Add(zeroLabel, 1, 3);

            var backLabel = new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = BackCharacter, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            AttachGestures(backLabel, BackCharacter);
            this.Children.Add(backLabel, 2, 3);
        }

        private void AttachGestures(Label label, object value)
        {
            label.GestureRecognizers.Add(new PressedGestureRecognizer() { Command = PressedCommand, CommandParameter = new GestureEventArgs() { Sender = label, Value = value } });
        }

        public const string BackCharacter = "<";

        private RelayCommand _pressedCommand = null;
        private RelayCommand PressedCommand
        {
            get
            {
                if (_pressedCommand == null)
                    _pressedCommand = new RelayCommand((parameter) =>
                    {

                        var args = parameter as GestureEventArgs;

                        if (Command != null)
                            Command.Execute(args.Value);

                        var label = args.Sender as Label;
                        label.BackgroundColor = Color.White;
                        label.TextColor = Color.Black;

                        Device.StartTimer(TimeSpan.FromMilliseconds(250), () =>
                        {
                            label.BackgroundColor = Color.Black;
                            label.TextColor = Color.White;

                            return false;
                        });

                    });

                return _pressedCommand;
            }

        }



        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(Keypad), null, BindingMode.Default, null, null, null, null, null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(Keypad), null, BindingMode.Default, null, null, null, null, null);

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

        public object CommandParameter
        {
            get
            {
                return this.GetValue(CommandParameterProperty);
            }
            set
            {
                this.SetValue(CommandParameterProperty, value);
            }
        }

    }
}
