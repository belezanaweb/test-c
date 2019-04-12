using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using API.Controllers;
using Services.Services;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyInjection();
        }

        public static void DependencyInjection()
        {
            var container = new CompositionContainer();
            container.ComposeParts(typeof(ProductController), new ProductService());
        }
    }
}
