using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CSharpLearningWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //326
            //IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            IWebHostBuilder builder = WebHost.CreateDefaultBuilder<Startup>(args);
            IWebHost host = builder.Build();
            host.Run();
        }

        //327
        public void SetWebUrlByThreeWays()
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:6500");
            builder.Build().Run();
        }

    }
}
