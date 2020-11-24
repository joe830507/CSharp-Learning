using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Example343
{
    public class CalcuMiddleware
    {
        readonly RequestDelegate _next;
        readonly int _a, _b;
        public CalcuMiddleware(RequestDelegate next, int a, int b)
        {
            _next = next;
            _a = a;
            _b = b;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            int result = _a * _b;
            context.Response.ContentType = "text/html;charset=UTF-8";
            await context.Response.WriteAsync($"{_a}x{_b}={result}");
        }
    }
}
