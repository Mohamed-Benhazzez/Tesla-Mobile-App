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
        public BaseViewModel(IAuthModel authModel, IExrinContainer exrinContainer, IVisualState visualState, [CallerFilePath] string caller = nameof(BaseViewModel))
             : base(exrinContainer, visualState, caller)
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
                    if (ViewStatus == VisualStatus.Visible && values.OldValue != values.NewValue && (bool)values.NewValue == false) // Changed to unauthenticated
                    {
                       
                        // Show Dialog / Move to Auth Stack
                        Exrin.Common.ThreadHelper.RunOnUIThread(async () =>
                        {
                            await _displayService.ShowDialog("Authentication", "Authentication is no longer valid. Please login again"); //TODO: Set resources, allow for localization
                            _stackRunner.Run(Stacks.Authentication);
                        });
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
