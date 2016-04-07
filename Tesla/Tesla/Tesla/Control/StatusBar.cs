using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tesla.Control
{
    public class StatusBar: Grid
    {
        // animation - runs length, stops and goes full length and green, then fades

        public static BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(StatusBar), propertyChanged: OnIsRunningChanged); 

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        private static void OnIsRunningChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var newValue = newvalue as bool;

        }



        public StatusBar()
        {

        }
        // bottom bar

    }
}
