using EmployeePayslipWebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeePayslipWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var enableCorsAttribute = new EnableCorsAttribute("*",
                                               "*",
                                               "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);
            // Web API routes
            config.MapHttpAttributeRoutes();

           // config.Filters.Add(new ValidateModelAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
