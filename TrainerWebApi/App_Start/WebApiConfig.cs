using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TrainerWebApi.DAL;
using TrainerWebApi.Filters.Action;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;
using TrainerWebApi.Services;

namespace TrainerWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableSystemDiagnosticsTracing();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Filters.Add(new ModelValidationFilter());
            config.Filters.Add(new BasicAuthenticationFilter(new AuthenticationService(new GenericRepository<User>(new TrainerContext())))); 
        }
    }
}
