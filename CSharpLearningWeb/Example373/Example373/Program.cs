using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Example373
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
                    webBuilder.UseConfiguration(GetConfiguration(args).Build());
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                });
        public static ConfigurationBuilder GetConfiguration(string[] args)
        {
            var c = new ConfigurationBuilder();
            IDictionary<string, string> mapping = new Dictionary<string, string>
            {
                ["--u"] = "urls",
                ["--env"] = "environment"
            };
            c.AddCommandLine(args, mapping);
            return c;
        }
    }
}
