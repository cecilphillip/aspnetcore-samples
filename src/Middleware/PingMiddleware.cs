using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Middleware
{
    public class PingMiddleware
    {
        private readonly RequestDelegate _next;
        private const string PingMe = "X-PingMe";
        private const string PingBack = "X-PingBack";
        private readonly ILogger _logger;

        public PingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._logger = loggerFactory.CreateLogger<PingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;
            if (headers.ContainsKey(PingMe))
            {
                var value = headers[PingMe];

                _logger.LogTrace("Pinging {0}", value);

                context.Response.Headers[PingBack] = $"HI {value}";
                context.Response.StatusCode = (int)HttpStatusCode.Accepted;
                return;
            }

            await _next(context);
        }
    }
}