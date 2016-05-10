using Exrin.Abstraction;
using Exrin.Framework;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;

namespace Tesla.Model
{
    /// <summary>
    /// Manages the applications user authentication and state
    /// </summary>
    public class AuthModel : BaseModel, IAuthModel
    {
		private readonly IAuthenticationService _service = null;
        public AuthModel(IDisplayService displayService, IApplicationInsights applicationInsights, IErrorHandlingService errorHandlingService, IAuthenticationService service)
            : base(displayService, applicationInsights, errorHandlingService, new AuthModelState())
        { _service = service; }
             
        public IAuthModelState AuthModelState { get { return ModelState as IAuthModelState; } }

        public Task AuthenticatedExpired()
        {
            AuthModelState.IsAuthenticated = false;

            // TODO: What needs to hook on here to force the UI to go back to login? and display a dialog.

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
