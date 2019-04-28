using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringDotNetCoreDemo.Infrastructure.Middleware
{
    public class ResponseEditingMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;

        public ResponseEditingMiddleware(RequestDelegate next)
        {
            _nextMiddleware = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _nextMiddleware.Invoke(httpContext);

            
            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response
                    .WriteAsync("Page not found. But dont worry we have dispatched a team of highly monkeys to find your page.", Encoding.UTF8);
            }
        }
    }
}