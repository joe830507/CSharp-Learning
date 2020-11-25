using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Example368
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            env.WebRootPath = Directory.GetCurrentDirectory();
            Console.WriteLine(env.WebRootPath);
            StaticFileOptions sfoption = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, "./js")),
                //ex. http://localhost:port/js/jquery-3.5.1.min.js
                RequestPath = "/js"
            };
            app.UseStaticFiles(sfoption);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            
        }
    }
}
