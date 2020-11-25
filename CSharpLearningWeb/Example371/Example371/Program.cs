using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Example371
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
                    webBuilder.UseConfiguration(GetConfigurationBuilder().Build());
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseStartup<Startup>();
                });
        public static ConfigurationBuilder GetConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder();
            builder.AddEnvironmentVariables("APP_");
            return builder;
        }
    }
    [Route("[controller]/[action]")]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
