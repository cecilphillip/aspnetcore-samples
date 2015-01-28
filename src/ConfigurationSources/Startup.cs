using Microsoft.AspNet.Builder;
using Microsoft.Framework.ConfigurationModel;

namespace ConfigurationOptions
{
    public class Startup
    {
		public Startup()
		{
			Configuration = new Configuration()
						 .AddJsonFile("config.json")
						 .AddIniFile("config.ini");
        }
		public IConfiguration Configuration { get; set; }
		public void Configure(IApplicationBuilder app)
        {
			//from config.json
			var setting = Configuration.Get("setting");
			var number = Configuration.Get("number");			
		  	var supper = Configuration.GetSubKey("upper")
						.GetSubKey("nested")
						.Get("innerValue");

			//from config.ini
			var connectionString = Configuration.Get("DefaultConnection:ConnectionString");
			var provider = Configuration.Get("Data:Inventory:SubHeader:Provider");
        }
    }	
}
