﻿using BelezaWeb.Infra.ExceptionHandler.Midlewares;
using BelezaWeb.Infra.ExceptionHandler.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BelezaWeb.Infra.ExceptionHandler.Extension
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseNativeGlobalExceptionErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    // _logger.LogCritical(exception, "Global exception", "");

                    var errorResponse = new ErrorResponse();

                    if (exception is HttpException httpException)
                    {
                        errorResponse.StatusCode = httpException.StatusCode;
                        errorResponse.Message = httpException.Message;
                    }

                    context.Response.StatusCode = (int)errorResponse.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorResponse.ToJsonString());
                });
            });

            return app;
        }

        public static IApplicationBuilder UseGlobalExceptionErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
