using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Hello
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app) => app.Run(context => context.Response.WriteAsync("Hello mate!!"));
    }
}