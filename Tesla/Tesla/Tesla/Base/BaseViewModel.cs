using Exrin.Abstraction;
using Exrin.Framework;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeslaDefinition;
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
                            _navigationService.Navigate(new StackOptions() { StackChoice = Stacks.Authentication });
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
