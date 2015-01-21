using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.ConfigurationModel;

namespace ConfigurationOptions
{
    public class Startup
    {
		public Startup()
		{
			Configuration = new Configuration()
						 .AddJsonFile("config.json");
        }
		public IConfiguration Configuration { get; set; }
		public void Configure(IApplicationBuilder app)
        {
			var setting = Configuration.Get("setting");
			var number = Configuration.Get("number");
			var upperWrong = Configuration.Get("upper");
		  	var supper = Configuration.GetSubKey("upper")
						.GetSubKey("nested")
						.Get("innerValue");
			


        }
    }	
}
