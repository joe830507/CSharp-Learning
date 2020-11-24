using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Example344
{
    public class TestMiddleware : IMiddleware
    {
        readonly RequestDelegate _next;
        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
            Console.WriteLine($"Class:{GetType().Name} is called.");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers["item1"] = "hello";
            context.Response.Headers["item2"] = "hi";
            context.Response.ContentType = "text/html;charset=UTF-8";
            await context.Response.WriteAsync("Welcome to home page.");
        }
    }
}
