using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

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
			this._logger = loggerFactory.Create<PingMiddleware>();
		}

		public async Task Invoke(HttpContext context)
		{
			var headers = context.Request.Headers;
			if (headers.ContainsKey(PingMe))
			{				
				var value = headers.Get(PingMe);

				_logger.WriteVerbose("Pinging {0}", value);

				context.Response.Headers[PingBack] = string.Format("HI {0}", value);
				context.Response.StatusCode = (int)HttpStatusCode.Accepted;
				return;
			}

			await _next(context);
		}
	}

	public static class PingMiddlewareExtensions
	{		
		public static IApplicationBuilder UsePing( this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<PingMiddleware>();
		}
	}
}