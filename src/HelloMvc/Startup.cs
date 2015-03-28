using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace HelloMvc
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {			
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services to the services container.
            services.AddMvc();    
			       
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseErrorPage(ErrorPageOptions.ShowAll);                        

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}