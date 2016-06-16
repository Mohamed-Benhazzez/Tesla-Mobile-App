using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Model;

namespace Tesla.ViewModel
{
	public class BookingVisualState : VisualState
	{
		public BookingVisualState(IServiceModel model) : base(model) { }

        public Booking Booking
        {
            get {
            
                var b = Get<Booking>();
                return b;
            }
            set { Set(value); }
        }
    }
}
