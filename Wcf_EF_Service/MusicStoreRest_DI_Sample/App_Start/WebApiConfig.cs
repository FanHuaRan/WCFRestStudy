using MusicStoreRest_DI_Sample.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MusicStoreRest_DI_Sample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //注册依赖注入容器
            config.DependencyResolver = new NinjectDependencyResolver(new Ninject.StandardKernel());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
