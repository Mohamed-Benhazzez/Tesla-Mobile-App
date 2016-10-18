using Exrin.Abstraction;
using Tesla.Droid.Platform;
using TeslaDatabase.Interfaces.Platform;

namespace Tesla.Droid
{
    public class Bootstrapper : IPlatformBootstrapper
    {
        public void Register(IInjectionProxy injection)
        {
            injection.RegisterInterface<IPlatformDatabase, Database>(InstanceType.SingleInstance);
        }
    }
}