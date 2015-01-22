using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

#if ASPNET50
using Microsoft.Owin.Builder;
using Owin;
#endif


namespace Middleware
{
	using AppFunc = Func<IDictionary<string, object>, Task>;

	public class OldPingMiddleware
	{
		private readonly Func<IDictionary<string, object>, Task> _next;
		private const string PingMe = "X-PingMe";
		private const string PingBack = "X-PingBack";

		public OldPingMiddleware(Func<IDictionary<string, object>, Task> next)
		{
			this._next = next;
		}

		public async Task Invoke(IDictionary<string, object> env)
		{
			var headers = (IDictionary<string, string[]>)env["owin.RequestHeaders"];

			if (headers.Keys.Contains(PingMe))
			{
				var value = headers[PingMe].FirstOrDefault();
				var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];
				responseHeaders[PingBack] = new[] { string.Format("HI {0}", value) };
				env["owin.ResponseStatusCode"] = 202;

				return;
			}

			await _next(env);
		}
	}

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
		public static IApplicationBuilder UsePing(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<PingMiddleware>();
		}

#if ASPNET50
		public static IApplicationBuilder UseAppBuilder(this IApplicationBuilder app, Action<IAppBuilder> configure)
		{
			app.UseOwin(pipeline =>
			{
				pipeline(next =>
				{
					var appBuilder = new AppBuilder();
					appBuilder.Properties["builder.DefaultApp"] = next;

					configure(appBuilder);

					return appBuilder.Build<AppFunc>();
				});
			});
			return app;
		}
#endif
	}
}