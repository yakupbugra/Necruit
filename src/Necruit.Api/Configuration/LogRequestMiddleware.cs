using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Necruit.Api.Configuration
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LogRequestMiddleware> _logger;
        private Func<string, Exception, string> _defaultFormatter = (state, exception) => state;

        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
            _logger.LogInformation($"REQUEST URL: {url} METHOD: {context.Request.Method} " + (requestBodyText.Length > 0 ? $"BODY: {requestBodyText} " : ""));

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await next(context);
            context.Request.Body = originalRequestBody;
        }
    }
}