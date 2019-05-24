using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BelezaNaWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{sku}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
