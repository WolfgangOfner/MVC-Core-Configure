using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringDotNetCoreDemo.Infrastructure.Middleware
{
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            _nextMiddleware = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("chrome")))
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _nextMiddleware.Invoke(httpContext);
            }
        }
    }
}