using Boticario.Api.ViewModels;
using Boticario.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Api.Extensions
{
    public class ExceptionMiddleware
    {
        #region Attributes

        private readonly RequestDelegate _next;

        #endregion

        #region Constructors

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Public Methods

        public async Task InvokeAsync(HttpContext httpContext, ILogger logger, INotificator notificator)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex, logger, notificator);
            }
        }

        #endregion

        #region Private Methods

        private void HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger, INotificator notificator)
        {
            logger.LogException(exception);

            var responseBody = new ResponseViewModel
            {
                success = false,
                errors = notificator.GetErrors().Select(x => x.Message).ToList()
            };

            responseBody.errors.Add(exception.Message);

            var responseJson = JsonConvert.SerializeObject(responseBody);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
            context.Response.WriteAsync(responseJson, Encoding.UTF8);
        }

        #endregion
    }
}