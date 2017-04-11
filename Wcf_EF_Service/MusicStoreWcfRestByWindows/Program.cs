using MusicStoreDAL.EntityContext;
using MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestByWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var host = new WebServiceHost(typeof(EmployeesService)))
            //{
            //    host.Open();
            //    Console.Read();
            //}
            System.Data.Entity.Database.SetInitializer<MusicStoreContext>(new SampleData());
            var hosts = new List<WebServiceHost>()
            {
                new WebServiceHost(typeof(EmployeesService)),
                new WebServiceHost(typeof(WCFAlbumService)),
                new WebServiceHost(typeof(WCFArtistService)),
                new WebServiceHost(typeof(WCFGenreService)),
                new WebServiceHost(typeof(WCFOrderService)),
                new WebServiceHost(typeof(WCFOrderDetailService))
            };
            hosts.ForEach(host =>
            {
                host.Open();
            });
            Console.ReadLine();
            hosts.ForEach(host =>
            {
                host.Close();
            });
        }
    }
}
