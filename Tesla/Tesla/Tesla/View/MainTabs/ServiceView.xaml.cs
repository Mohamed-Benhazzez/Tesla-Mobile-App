using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using Tesla.ViewModel;
using Xamarin.Forms;

namespace Tesla.View.MainTabs
{
	public partial class ServiceView : BaseView
	{
		public ServiceView()
		{
			InitializeComponent();
		}

        // TODO: Change this to a behavior, keep the xaml clean.
        protected void ItemSelected(object sender, EventArgs e)
        {
            ((ServiceViewModel)this.BindingContext).ViewBookingCommand.Execute(((ListView)sender).SelectedItem);
        }
	}
}
