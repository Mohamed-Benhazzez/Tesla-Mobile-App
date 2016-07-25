namespace TeslaDefinition.Interfaces.Model
{
    using Exrin.Abstraction;
    using System.Threading.Tasks;

    public interface IAuthModel: IBaseModel
    {
        // State
        IAuthModelState AuthModelState { get; }
        
        // State Validation
        Task<bool> IsAuthenticated();
        Task<bool> IsPinComplete();
        Task AuthenticationExpired();
    }
}
