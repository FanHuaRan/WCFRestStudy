using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MusicStoreWebAPIByWCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化http自寄宿配置对象
            var config = new HttpSelfHostConfiguration("http://localhost:18080");
            //启用特性路由并注册默认路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi ",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            //实例化自托管服务器
            using (var server = new HttpSelfHostServer(config))
            {
                //打开服务器
                server.OpenAsync().Wait();
                Console.WriteLine("api server is listening http://localhost:18080 ");
                Console.WriteLine("enter to exit");
                Console.ReadLine();
            }

        }
    }
}
