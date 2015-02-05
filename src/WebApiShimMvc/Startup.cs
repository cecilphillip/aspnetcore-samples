using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;

namespace WebApiShimMvc
{
    public class Startup
    {
        public Startup()
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }        

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
			loggerfactory.AddConsole();
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddWebApiConventions();
            });

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller}/{action}",
                //    defaults: new { controller = "Home", action = "Index" });

                routes.MapWebApiRoute("DefaultApi", "api/{controller}/{action}");
            });
        }
    }
}
