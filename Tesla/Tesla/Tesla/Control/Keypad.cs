using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var label = new Label() { HorizontalOptions= LayoutOptions.FillAndExpand, VerticalOptions=LayoutOptions.FillAndExpand, BackgroundColor = backgroundColor, TextColor = textColor, Text = (i + 1).ToString(), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
                label.GestureRecognizers.Add(new TapGestureRecognizer() { Command = ButtonTap, CommandParameter = i.ToString() });
                label.GestureRecognizers.Add(new PressedGestureRecognizer() { Command = PressedCommand, CommandParameter = label });
                label.GestureRecognizers.Add(new ReleasedGestureRecognizer() { Command = ReleasedCommand, CommandParameter = label });
                this.Children.Add(label, i - ((i / 3) * 3), i / 3);
            }

            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 0, 3);
            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "0", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 1, 3);
            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "<", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 2, 3);
        }

        private RelayCommand _buttonTap = null;
        private RelayCommand ButtonTap
        {
            get
            {
                if (_buttonTap == null)
                    _buttonTap = new RelayCommand((parameter) =>
                    {
                        if (Command != null)
                            Command.Execute(parameter);

                    });

                return _buttonTap;
            }
        }

        private RelayCommand _pressedCommand = null;
        private RelayCommand PressedCommand
        {
            get
            {
                if (_pressedCommand == null)
                    _pressedCommand = new RelayCommand((parameter) =>
                    {
                        var label = parameter as Label;
                        label.BackgroundColor = Color.Black;
                        label.TextColor = Color.White;
                    });

                return _pressedCommand;
            }

        }

        private RelayCommand _releasedCommand = null;
        private RelayCommand ReleasedCommand
        {
            get
            {
                if (_releasedCommand == null)
                    _releasedCommand = new RelayCommand((parameter) =>
                    {
                        var label = parameter as Label;
                        label.BackgroundColor = Color.White;
                        label.TextColor = Color.Black;
                    });

                return _releasedCommand;
            }

        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(TapGestureRecognizer), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(TapGestureRecognizer), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

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
