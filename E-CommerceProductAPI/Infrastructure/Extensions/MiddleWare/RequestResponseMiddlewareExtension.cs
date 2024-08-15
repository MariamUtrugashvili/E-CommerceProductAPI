using E_CommerceProductAPI.Infrastructure.Middleware;

namespace E_CommerceProductAPI.Infrastructure.Extensions.MiddleWare
{
    public static class RequestResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
