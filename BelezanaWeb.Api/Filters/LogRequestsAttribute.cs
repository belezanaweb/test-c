using Microsoft.AspNetCore.Mvc.Filters;

namespace BelezanaWeb.Api.Filters
{
    public class LogsRequestsAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //bool grayLogAble = AppSettings.Get<bool>("Able");
            //if (grayLogAble)
            //    PostToGrayLog(context);
        }

        private async void PostToGrayLog(ActionExecutingContext context)
        {
            try
            {
                var CA = ControllerNameActionName(context);
                
                var log = new
                {
                    application_name = "BelezanaWeb",
                    short_message = string.Format("Acessos: Logs de Acesso BelezanaWeb. Action: {0}.{1}.", CA.Controller, CA.Action),
                    type_log = "Acessos",
                    ActionArguments = context.ActionArguments,
                    Method = context.HttpContext.Request.Method,
                    Ip = context.HttpContext.Connection.RemoteIpAddress != null ? context.HttpContext.Connection.RemoteIpAddress.ToString() : "",
                    UserName = context.HttpContext.Request.HttpContext.User.Identity.Name,
                    Action = CA.Action,
                    Controller = CA.Controller,
                    HostName = context.HttpContext.Request.Host,
                    Page = context.HttpContext.Request.Path

                };

                //await LogHelper.PostJsonToGrayLogAsync(log);
            }
            catch
            {
                // N�o fazer nada por enquanto. Apenas para n�o estourar erro 502 na aplica��o.
            }
        }

        public dynamic ControllerNameActionName(ActionExecutingContext context)
        {
            var ControllerAction = new
            {
                Controller = ((Microsoft.AspNetCore.Mvc.ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName,
                Action = ((Microsoft.AspNetCore.Mvc.ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName,
            };
            return ControllerAction;
        }

    }

}

