using System;
using System.Net;
using System.Linq;
using FluentValidation;
using BelezaNaWeb.Api.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BelezaNaWeb.Api.Extensions;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Helpers;

namespace BelezaNaWeb.Api.Infrastructure.Middlewares
{
    public class ApiExceptionMiddleware
    {
        #region Private Read-Only Fields

        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        #endregion

        #region Constructors

        public ApiExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<ApiExceptionMiddleware>();
        }

        #endregion

        #region Public Methods

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        #endregion

        #region Private Methods

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var response = default(ErrorResponseDto);
            httpContext.Response.ContentType = "application/json";

            if (exception is ArgumentNullException || exception is ArgumentException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response = ErrorResponseDto.DefaultBadRequestResponse();
            }
            else if (exception is ValidationException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                response = ErrorResponseDto.DefaultBadRequestResponse();
                response.Details = (exception as ValidationException).Errors
                    .Select(x => new ErrorFieldDto(field: x.PropertyName, value: x.ErrorMessage));
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = ErrorResponseDto.DefaultInternalServerErrorResponse();
            }

            if (!response.Details.Any() && exception.GetInnerExceptions().Any())
                response.Details = exception.GetInnerExceptions()
                    .Select(x => new ErrorFieldDto(field: null, value: x.Message))
                    .ToList();

            _logger.LogError(exception, response.Message);
            return httpContext.Response.WriteAsync(SerializationHelper.SerializeToJson(response));
        }

        #endregion
    }
}
