using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.ViewModel;
using TeslaDefinition.Interfaces.Model;
using Xunit;

namespace Tesla.Tests.ViewModel.PinViewModel
{
    public class PinVisualStateTest
    {

        public static TheoryData<Tuple<IPinModel, string>> GetPinModel(string pin)
        {
            return new TheoryData<Tuple<IPinModel, string>>() { new Tuple<IPinModel, string>(new Tesla.Model.PinModel(CommonService.DisplayService, CommonService.ErrorHandlingService), pin) };
        }
        
        [Theory]
        [MemberData(nameof(GetPinModel), "")]
        [MemberData(nameof(GetPinModel), "2344")]
        public void HiddenPinTest(Tuple<IPinModel, string> parameters)
        {
            var visualState = new PinVisualState(parameters.Item1);

            parameters.Item1.Pin = parameters.Item2;

            if (String.IsNullOrEmpty(parameters.Item2))
                Assert.Equal("enter pin", visualState.HiddenPin);
            else
                Assert.Equal(string.Empty.PadLeft(parameters.Item1.Pin.Length, '•'), visualState.HiddenPin);
        }

    }
}
