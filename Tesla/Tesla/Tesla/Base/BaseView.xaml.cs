using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tesla.Base
{
    public partial class BaseView : ContentPage, IView
    {
        public BaseView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return ((IView)this).OnBackButtonPressed();
        }

        Func<bool> IView.OnBackButtonPressed
        { get; set; }
    }
}
