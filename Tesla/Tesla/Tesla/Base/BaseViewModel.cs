using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition;
using TeslaDefinition.Interfaces;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Base
{
    public class BaseViewModel : Exrin.Framework.ViewModel
    {
        public BaseViewModel(IAuthModel authModel, IApplicationInsights applicationInsights, IDisplayService displayService, INavigationService navigationService,
            IErrorHandlingService errorHandlingService, IStackRunner stackRunner, IVisualState visualState, [CallerFilePath] string caller = nameof(BaseViewModel))
             : base(applicationInsights, displayService, navigationService, errorHandlingService, stackRunner, visualState, caller)
        { AuthModel = authModel; Init(); }

        protected IAuthModel AuthModel { get; set; }

        private void Init()
        {
            var state = AuthModel.ModelState as IAuthModelState;
            state.PropertyChanged += State_PropertyChanged;
        }

        private void State_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IAuthModelState.IsAuthenticated))
            {
                var values = e as PropertyValueChangedEventArgs;
                if (values != null)
                    if (values.OldValue != values.NewValue && (bool)values.NewValue == false) // Changed to unauthenticated
                    {
                        // Show Dialog / Move to Auth Stack
                    }

            }
        }

        public override void Disposing()
        {
            base.Disposing();

            var state = AuthModel.ModelState as IAuthModelState;
            state.PropertyChanged -= State_PropertyChanged;

        }

    }
}
