using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringDotNetCoreDemo.Infrastructure.Middleware
{
    public class RequestEditingMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;

        public RequestEditingMiddleware(RequestDelegate next)
        {
            _nextMiddleware = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("edge"));

            await _nextMiddleware.Invoke(httpContext);
        }
    }
}