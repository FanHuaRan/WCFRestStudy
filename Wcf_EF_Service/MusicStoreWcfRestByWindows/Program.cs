using MusicStoreDAL.EntityContext;
using MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestByWindows
{
    /// <summary>
    /// 利用windows程序进行自托管
    /// 服务的生命周期全部自己管理
    /// 2017/04/15
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var hosts = new ServiceHostArray())
            {
                hosts.ServiceHosts = new List<WebServiceHost>()
                {
                    new WebServiceHost(typeof(EmployeesService)),
                    new WebServiceHost(typeof(WCFAlbumService)),
                    new WebServiceHost(typeof(WCFArtistService)),
                    new WebServiceHost(typeof(WCFGenreService)),
                    new WebServiceHost(typeof(WCFOrderService)),
                    new WebServiceHost(typeof(WCFOrderDetailService))
                 };
                hosts.Open();
                Console.WriteLine("服务已全部打开,回车关闭");
                Console.ReadLine();
            }
        }
    }
}
