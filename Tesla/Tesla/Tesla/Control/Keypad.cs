using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = (i + 1).ToString(), HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, i - ((i / 3) * 3), i / 3);

            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 0, 3);
            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "0", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 1, 3);
            this.Children.Add(new Label() { BackgroundColor = backgroundColor, TextColor = textColor, Text = "<", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 2, 3);
        }

    }
}
