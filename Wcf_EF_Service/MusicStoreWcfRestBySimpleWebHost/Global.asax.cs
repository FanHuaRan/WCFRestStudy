using MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using MusicStoreWcfRestContract.EnableCacheServiceContract;
namespace MusicStoreWcfRestBySimpleWebHost
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ///////服务直接在Web中的RouteTable进行路由注册即可完成服务寄宿

            ////带缓存的服务
            RouteTable.Routes.Add(new ServiceRoute("Employees", new WebServiceHostFactory(), typeof(MusicStoreWcfRestService.EnableCache.EmployeesService)));//注意：服务类型是实现服务的类。
            RouteTable.Routes.Add(new ServiceRoute("Albums", new WebServiceHostFactory(), typeof(MusicStoreWcfRestService.EnableCache.WCFAlbumService)));//注意：服务类型是实现服务的类。
            RouteTable.Routes.Add(new ServiceRoute("Genres", new WebServiceHostFactory(), typeof(MusicStoreWcfRestService.EnableCache.WCFGenreService)));//注意：服务类型是实现服务的类。
            RouteTable.Routes.Add(new ServiceRoute("Artists", new WebServiceHostFactory(), typeof(MusicStoreWcfRestService.EnableCache.WCFArtistService)));//注意：服务类型是实现服务的类。
            RouteTable.Routes.Add(new ServiceRoute("Orders", new WebServiceHostFactory(), typeof(MusicStoreWcfRestService.EnableCache.WCFOrderService)));//注意：服务类型是实现服务的类。
            RouteTable.Routes.Add(new ServiceRoute("OrderDetails", new WebServiceHostFactory(), typeof(MusicStoreWcfRestService.EnableCache.WCFOrderDetailService)));//注意：服务类型是实现服务的类。
            ////不带缓存的服务
            //RouteTable.Routes.Add(new ServiceRoute("Employees", new WebServiceHostFactory(), typeof(EmployeesService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("Albums", new WebServiceHostFactory(), typeof(WCFAlbumService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("Genres", new WebServiceHostFactory(), typeof(WCFGenreService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("Artists", new WebServiceHostFactory(), typeof(WCFArtistService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("Orders", new WebServiceHostFactory(), typeof(WCFOrderService)));//注意：服务类型是实现服务的类。
            //RouteTable.Routes.Add(new ServiceRoute("OrderDetails", new WebServiceHostFactory(), typeof(WCFOrderDetailService)));//注意：服务类型是实现服务的类。
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}