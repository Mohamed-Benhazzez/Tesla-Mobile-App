using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.Model
{
    /// <summary>
    /// Manages the applications user authentication and state
    /// </summary>
    public class AuthModel : BaseModel, IAuthModel
    {
        public AuthModel(IDisplayService displayService, IApplicationInsights applicationInsights, IErrorHandlingService errorHandlingService)
            : base(displayService, applicationInsights, errorHandlingService, new AuthModelState())
        { }
             
        public IAuthModelState AuthModelState { get { return ModelState as IAuthModelState; } }
        
        public Task<bool> IsAuthenticated()
        {
            return Execution.ModelExecute(new IsAuthenticated(AuthModelState.Pin));
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
