using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.ViewModel.MainTabs
{
    public class ControlVisualState: VisualState
    {
        public ControlVisualState(IBaseModel model) : base(model) { }

        public string ProximityLocationStatus { get { return Get<string>(); } private set { Set(value); } }
        public string SummonStatus { get { return Get<string>(); } private set { Set(value); } }
    }
}
