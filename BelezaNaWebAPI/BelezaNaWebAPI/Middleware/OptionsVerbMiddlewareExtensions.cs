using Microsoft.AspNetCore.Builder;

namespace BelezaNaWebAPI
{
    public static class OptionsVerbMiddlewareExtensions
    {
        public static IApplicationBuilder UseOptionsVerbHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware.OptionsVerbMiddleware>();
        }
    }
}
