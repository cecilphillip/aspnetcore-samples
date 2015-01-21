using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace Hello
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
			app.Run(context => context.Response.WriteAsync("Hello!!"));			
		}
    }
}
