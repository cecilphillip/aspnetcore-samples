using Microsoft.AspNet.Builder;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;

#if ASPNET50
using Owin;
#endif


namespace Middleware
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			//app.UseMiddleware<PingMiddleware>();
			//app.UsePing();
			//app.UseOwin(pipeline =>
			//{
			//	pipeline(next =>  Invoke);
			//});

#if ASPNET50
			app.UseAppBuilder(builder => builder.Use(typeof(OldPingMiddleware)));
#endif
			//app.UseWelcomePage();
		}

		public Task Invoke(IDictionary<string, object> environment)
		{
			string responseText = "Hello World";
			byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

			// See http://owin.org/spec/owin-1.0.0.html for standard environment keys.
			var responseStream = (Stream)environment["owin.ResponseBody"];
			var responseHeaders = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];

			responseHeaders["Content-Length"] = new string[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
			responseHeaders["Content-Type"] = new string[] { "text/plain" };

			return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
		}
	}
}