using Microsoft.Extensions.Logging;

namespace Necruit.Application.Service
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