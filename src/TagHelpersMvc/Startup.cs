using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace TagHelpersMvc
{
	public class Startup
    {
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddMvc();
        }
       
        public void Configure(IApplicationBuilder app)
        {   
            app.UseErrorHandler("/Home/Error");

            // Add static files to the request pipeline.
            app.UseStaticFiles();

                    
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