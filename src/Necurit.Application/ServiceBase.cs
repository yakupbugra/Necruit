using Microsoft.Extensions.Logging;

namespace Necurit.Application
{
    public class ServiceBase
    {
        internal ILogger Logger;

        public ServiceBase(ILogger Logger)
        {
            this.Logger = Logger;
        }
    }
}