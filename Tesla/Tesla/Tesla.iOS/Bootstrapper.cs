using Exrin.Abstraction;
using Tesla.iOS.Platform;
using TeslaDatabase.Interfaces.Platform;

namespace Tesla.iOS
{
    public class Bootstrapper : IPlatformBootstrapper
    {
        public void Register(IInjectionProxy injection)
        {
            injection.RegisterInterface<IPlatformDatabase, Database>(InstanceType.SingleInstance);
        }
    }
}