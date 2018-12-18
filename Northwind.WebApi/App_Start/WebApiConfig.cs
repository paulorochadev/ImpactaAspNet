using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//---
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;


namespace Northwind.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web
            config.EnableCors( new EnableCorsAttribute("*", "*", "*"));

            config.Formatters.JsonFormatter
                .SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter
                .SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
