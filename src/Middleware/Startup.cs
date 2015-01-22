using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;


namespace Middleware
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
			app.UseMiddleware<PingMiddleware>();
			app.UsePing();
			app.UseWelcomePage();
        }
    }
}
