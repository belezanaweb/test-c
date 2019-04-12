using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Services.Services;

namespace API
{
    public static class WebApiConfig
    {
        public class CustomJsonFormatter : JsonMediaTypeFormatter
        {
            /// <inheritdoc />
            public CustomJsonFormatter() => SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            /// <inheritdoc />
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new CustomJsonFormatter());
            config.DependencyResolver = DependencyInjectionResolver();

        }

        /// <summary>
        /// Autofac dependency injector resolver.
        /// </summary>
        /// <returns>Autofac WebApi Dependency Resolver</returns>
        private static AutofacWebApiDependencyResolver DependencyInjectionResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.Load("Services"));
            builder.RegisterAssemblyModules(Assembly.Load("Model"));

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            return new AutofacWebApiDependencyResolver(container);
        }
    }
}
