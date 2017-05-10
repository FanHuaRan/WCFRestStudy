using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

namespace MusicStoreWebAPIByOWINHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            //实例化http配置对象
            var httpConfig = new HttpConfiguration();
            //启用特性路由并注册默认路由
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApi ",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            //使用配置对象来使用web api
            app.UseWebApi(httpConfig);
        }
    }
}
