using MusicStoreRestByWebHost.EntityContext;
using MusicStoreRestByWebHost.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Mvc;
using System.Web.Optimization;
using MusicStoreRestByWebHost.Services;
namespace MusicStoreRestByWebHost
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer<MusicStoreContext>(new SampleData());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
          //  RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(RouteTable.Routes);
            RouteTable.Routes.Add(new ServiceRoute("WCFAlbumService", new WebServiceHostFactory(), typeof(WCFAlbumService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("WCFArtsitService", new WebServiceHostFactory(), typeof(WCFArtsitService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("WCFGenreService", new WebServiceHostFactory(), typeof(WCFGenreService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("WCFOrderDetailService", new WebServiceHostFactory(), typeof(WCFOrderDetailService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("WCFOrderService", new WebServiceHostFactory(), typeof(WCFOrderService)));//注意：服务类型是实现服务的类。

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name

                "{controller}/{action}/{id}", // URL with parameters

                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults

                new { controller = @"^\b(?!uap)\w*\b$" }
            );
        }
    }
}
