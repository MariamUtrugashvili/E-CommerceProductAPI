using E_CommerceProductAPI.Infrastructure.Middleware;

namespace E_CommerceProductAPI.Infrastructure.Extensions.MiddleWare
{
    public static class GlobalExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExeptionsMiddleware>();
        }
    }
}
