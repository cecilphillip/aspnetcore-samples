using Microsoft.AspNet.Builder;
using System;
using System.Collections.Generic;

#if ASPNET50
using System.Threading.Tasks;
using Microsoft.Owin.Builder;
using Owin;
#endif

namespace Middleware
{
#if ASPNET50
    using AppFunc = Func<IDictionary<string, object>, Task>;
#endif

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