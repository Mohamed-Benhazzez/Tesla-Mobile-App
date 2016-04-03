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
        public AuthModel(IDisplayService displayService, IErrorHandlingService errorHandlingService)
            : base(displayService, errorHandlingService, new AuthModelState())
        { }
             
        public IAuthModelState AuthModelState { get { return ModelState as IAuthModelState; } }


        public Task<bool> IsAuthenticated()
        {
            return Execution.ModelExecute(new IsAuthenticated(AuthModelState.Pin));
        }
    }
    
}
