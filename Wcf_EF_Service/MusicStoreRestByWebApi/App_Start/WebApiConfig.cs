using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MusicStoreRestByWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            #region 关于路由的一些注意事项
            /*
             * 可以在此配置默认路由模板，看看下面的代码
             * 同时可以使用特性进行路由配置，完全和spring mvc一样
             * 另外ApiController的所有Get开头方法默认Get动作
             * 其它几个方法只有和动作名一样才默认对应的动作，在开头不起作用，
             * 只有与动作相同，然后与controller路由拼接
             */
            #endregion
            //启用特性配置路由
            config.MapHttpAttributeRoutes();
            #region 默认路由 反正我是很不习惯
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            #endregion
            #region 完善webapi路由 可以看看这篇文章：http://www.cnblogs.com/zhengwk/p/5505127.html
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi2",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
               name: "DefaultApi3",
               routeTemplate: "api/{controller}/{action}",
               defaults: new { action = RouteParameter.Optional }
           );
            #endregion
            //默认返回json  
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
            //   new QueryStringMapping("datatype", "json", "application/json"));
            ////返回格式选择 datatype 可以替换为任何参数   
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("datatype", "xml", "application/xml"));  
        }
    }
}
