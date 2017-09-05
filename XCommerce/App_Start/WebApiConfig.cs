using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace XCommerce
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var setting = config.Formatters.JsonFormatter.SerializerSettings;            
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Products",
            //    routeTemplate: "api/Products/{brandId}/{productId}",
            //    defaults: new { brandId = RouteParameter.Optional, productId = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Products",
            //    routeTemplate: "api/Products/{brandId}",
            //    defaults: new { brandId = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
