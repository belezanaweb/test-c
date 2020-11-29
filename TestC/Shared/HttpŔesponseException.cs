using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestC.ExceptionHandler
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message, int status = 400)
        {
            this.Status = status;
            this.Message = message;
        }

        public int Status { get; set; }

        public override string Message { get; }
    }
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Status)
                {
                    StatusCode = exception.Status,
                    Value = new {
                        statusCode = exception.Status,
                        messages = new []{ exception.Message }
                    }
                };
                context.ExceptionHandled = true;
            }
        }
    }
}