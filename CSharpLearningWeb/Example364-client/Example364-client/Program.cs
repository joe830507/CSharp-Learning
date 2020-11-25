using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Example364_client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PostFun();
            while (true)
            {
                string msg = Console.ReadLine();
                if (!string.IsNullOrEmpty(msg) && "end".Equals(msg))
                    break;
                else
                    Console.WriteLine("Type in your message.");
            }
        }

        public static async void PostFun()
        {
            string url = "http://localhost:5000/demo/uploadfile";
            string FileName = "sample.dat";
            int byteCount = 8000;
            byte[] bytes = new byte[byteCount];
            Random rand = new Random();
            rand.NextBytes(bytes);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("file-name", FileName);
                ByteArrayContent content = new ByteArrayContent(bytes);
                Console.WriteLine("Sending data...");
                HttpResponseMessage response = await client.PostAsync(url, content);
                string respmsg = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"StatusCode:{response.StatusCode}");
                Console.WriteLine($"Server returned message:{respmsg}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
