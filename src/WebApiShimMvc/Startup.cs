using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApiShimMvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            })
            .AddWebApiConventions();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole();

            app.UseDeveloperExceptionPage();

            app.UseMvc(routes =>
            {
                routes.MapWebApiRoute("DefaultApi", "api/{controller}/{action}");
            });
        }
    }
}
