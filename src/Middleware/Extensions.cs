using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public static class Extensions
    {
        public static IApplicationBuilder UsePing(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PingMiddleware>();
        }
    }
}