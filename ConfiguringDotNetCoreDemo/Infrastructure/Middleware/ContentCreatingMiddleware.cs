using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringDotNetCoreDemo.Infrastructure.Middleware
{
    public class ContentCreatingMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;

        public ContentCreatingMiddleware(RequestDelegate next)
        {
            _nextMiddleware = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/contentmiddleware")
            {
                await httpContext.Response.WriteAsync("Hello from the content creating middleware", Encoding.UTF8);
            }
            else
            {
                await _nextMiddleware.Invoke(httpContext);
            }
        }
    }
}