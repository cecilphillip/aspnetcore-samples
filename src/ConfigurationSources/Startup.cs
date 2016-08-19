using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ConfigurationOptions
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddIniFile("config.ini")
                .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

		public IConfiguration Configuration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
			//from config.json
			var setting = Configuration["setting"];
			var number = Configuration["number"];			
		  	var supper = Configuration.GetSection("upper")
						.GetSection("nested")["innerValue"];

			//from config.ini
			var connectionString = Configuration["DefaultConnection:ConnectionString"];
			var provider = Configuration["Data:Inventory:SubHeader:Provider"];
        }
    }	
}
