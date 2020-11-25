using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Example360
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
                    webBuilder.UseStartup<Startup>();
                });
    }
    public class DemoController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Description() => View();
        public ActionResult News() => View();
        public ActionResult Products() => View();
        public ActionResult ContactUs() => View();
    }
}
