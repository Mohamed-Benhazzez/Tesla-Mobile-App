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

        public static TheoryData<Tuple<IAuthModel, string>> GetPinModel(string pin)
        {
            return new TheoryData<Tuple<IAuthModel, string>>() { new Tuple<IAuthModel, string>(new Tesla.Model.AuthModel(CommonService.DisplayService, CommonService.ErrorHandlingService), pin) };
        }
        
        [Theory]
        [MemberData(nameof(GetPinModel), "")]
        [MemberData(nameof(GetPinModel), "2344")]
        public void HiddenPinTest(Tuple<IAuthModel, string> parameters)
        {
            var visualState = new PinVisualState(parameters.Item1);

            parameters.Item1.AuthModelState.Pin = parameters.Item2;

            if (string.IsNullOrEmpty(parameters.Item2))
                Assert.Equal(BusinessRules.EmptyHiddenPin, visualState.HiddenPin);
            else
                Assert.Equal(string.Empty.PadLeft(parameters.Item1.AuthModelState.Pin.Length, BusinessRules.HiddenChar), visualState.HiddenPin);
        }

    }
}
