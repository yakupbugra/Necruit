using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Necruit.Api.Configuration
{
    public class CorrelationMiddleware
    {
        internal const string CorrelationHeaderKey = "CorrelationId";
        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var correlationId = Guid.NewGuid();

            context.Request?.Headers.Add(CorrelationHeaderKey, correlationId.ToString());
            LogContext.PushProperty("CorrelationId", correlationId);
            
               
            
            await _next.Invoke(context);
        }
    }
}
