using Microsoft.AspNetCore.Builder;

namespace BelezaNaWebAPI
{
    public static class MiddlewareConfig
    {
        public static IApplicationBuilder UseSwaggerWithOptions(this IApplicationBuilder app)
        {            
            SwaggerBuilderExtensions.UseSwagger(app);

            app.UseSwaggerUI(c =>
            {
                // Uncomment this line if you want to access the Swagger UI as http://localhost:5000
                // c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint(Constants.Swagger.EndPoint, Constants.Swagger.ApiName);
            });

            return app;
        }
    }
}
