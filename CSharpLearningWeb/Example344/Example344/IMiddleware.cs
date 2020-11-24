using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Example344
{
    public interface IMiddleware
    {
        public Task InvokeAsync(HttpContext context);
    }
}
