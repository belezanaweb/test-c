using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Belezanaweb.Application.Core.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public GlobalExceptionHandlerMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                await HandleExceptionAsync(context, ex, (int)HttpStatusCode.BadRequest);
            }
            catch (ValidatorException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, (int)HttpStatusCode.InternalServerError);
            }
        }
        
        private Task HandleExceptionAsync(HttpContext context, ValidatorException payload)
        {
            ConfigureErrorResponse(context, (int)HttpStatusCode.BadRequest);

            var text = string.Empty;
            if (payload != null)
            {
                var errors = new List<string>();
                foreach (Exception ex in payload.Exceptions)
                {
                    errors.Add(ex.Message);
                }
                text = JsonConvert.SerializeObject(new Response(errors.ToArray()));
            }
            return context.Response.WriteAsync(text);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception payload, int statusCode)
        {
            ConfigureErrorResponse(context, statusCode);

            var text = string.Empty;
            if (payload != null)
            {
                text = JsonConvert.SerializeObject(new Response(payload.Message));
            }
            return context.Response.WriteAsync(text);
        }

        private void ConfigureErrorResponse(HttpContext context, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
        }

    }
}
