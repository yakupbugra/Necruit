using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Necurit.Application
{
    public class ServiceBase
    {
        internal ILogger Logger;

        public ServiceBase(ILogger Logger)
        {
            this.Logger = Logger;
        }

        public bool RunInTryCatch(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
