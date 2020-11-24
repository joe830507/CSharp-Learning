using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Example342.Middlewares
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate m_next;
        public SampleMiddleware(RequestDelegate next)
        {
            m_next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello Web");
        }
    }
}
