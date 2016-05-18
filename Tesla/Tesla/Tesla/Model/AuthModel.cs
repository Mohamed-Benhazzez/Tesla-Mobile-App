using Exrin.Abstraction;
using Exrin.Common;
using Exrin.Framework;
using System;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;
using Xamarin.Forms;

namespace Tesla.Model
{
    /// <summary>
    /// Manages the applications user authentication and state
    /// </summary>
    public class AuthModel : BaseModel, IAuthModel
    {
        private readonly IAuthenticationService _service = null;
        public AuthModel(IExrinContainer exrinContainer, IAuthenticationService service)
            : base(exrinContainer, new AuthModelState())
        {
            _service = service;

            // TEMP: Just to demonstrate the login function if AuthenticationExpired is called
            //ThreadHelper.RunOnUIThread(() =>
            //{
            //    Device.StartTimer(TimeSpan.FromSeconds(10), () => { AuthenticationExpired(); return false; });
            //});
        }

        public IAuthModelState AuthModelState { get { return ModelState as IAuthModelState; } }

        public Task AuthenticationExpired()
        {
            AuthModelState.IsAuthenticated = false;
            AuthModelState.Pin = "";

            return Task.FromResult(true);
        }

        public async Task<bool> IsAuthenticated()
        {
            return AuthModelState.IsAuthenticated = await Execution.ModelExecute(new IsAuthenticated(AuthModelState.Pin));
        }

        public Task<bool> IsPinComplete()
        {
            return Execution.ModelExecute(new IsPinValid(AuthModelState.Pin));
        }

        //TODO: Get Token for API based call, or current status of login.
        //Move back to Pin screen if authentication currently invalidated and can't revalidate
        //Would have to push back to the ViewModel - common ReAuth navigation
    }

}
