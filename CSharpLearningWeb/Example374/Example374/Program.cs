using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Example374
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(GetConfiguration().Build());
                    webBuilder.UseStartup<Startup>();
                });
        public static ConfigurationBuilder GetConfiguration()
        {
            var configbd = new ConfigurationBuilder();
            configbd.AddInMemoryCollection(GetConfig());
            return configbd;
        }
        public static IDictionary<string, string> GetConfig()
        {
            var data = new Dictionary<string, string>
            {
                ["environment"] = "Debug",
                ["urls"] = "http://localhost:990",
                ["contentRoot"] = Directory.GetCurrentDirectory(),
            };
            return data;
        }
    }
}
