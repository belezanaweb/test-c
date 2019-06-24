using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace BelezanaWeb.Api.Filters
{
    public class ExcetionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //bool grayLogAble = AppSettings.Get<bool>("Able");
            //if (grayLogAble)
            //    PostToGrayLog(context);

            int statusCode = (int)HttpStatusCode.BadRequest;
            if (context.Exception is UnauthorizedAccessException)
                statusCode = (int)HttpStatusCode.Unauthorized;

            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(context.Exception.Message);

            base.OnException(context);
        }

        private async void PostToGrayLog(ExceptionContext context)
        {
            try
            {

                var log = new
                {
                    application_name = "BelezanaWeb",
                    short_message = string.Format("Erros: Logs de Acesso BelezanaWeb."),
                    type_log = "Erros",
                    Method = context.HttpContext.Request.Method,
                    Ip = context.HttpContext.Connection.RemoteIpAddress != null ? context.HttpContext.Connection.RemoteIpAddress.ToString() : "",
                    UserName = context.HttpContext.Request.HttpContext.User.Identity.Name,
                    HostName = context.HttpContext.Request.Host,
                    Page = context.HttpContext.Request.Path,
                    exception_message = context.Exception.Message,
                    inner_exception = context.Exception.InnerException,
                    stack_trace = context.Exception.StackTrace
                };

                //await LogHelper.PostJsonToGrayLogAsync(log);
            }
            catch
            {
                // N�o fazer nada por enquanto. Apenas para n�o estourar erro 502 na aplica��o.
            }
        }

    }
}