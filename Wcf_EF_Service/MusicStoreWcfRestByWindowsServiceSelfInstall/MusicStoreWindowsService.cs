using MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestByWindowsServiceSelfInstall
{
    /// <summary>
    /// windows服务
    /// </summary>
    partial class MusicStoreWindowsService : ServiceBase
    {
        public List<WebServiceHost> hosts = new List<WebServiceHost>()
            {
                new WebServiceHost(typeof(EmployeesService)),
                new WebServiceHost(typeof(WCFAlbumService)),
                new WebServiceHost(typeof(WCFArtistService)),
                new WebServiceHost(typeof(WCFGenreService)),
                new WebServiceHost(typeof(WCFOrderService)),
                new WebServiceHost(typeof(WCFOrderDetailService))
            };
        public MusicStoreWindowsService()
        {
            InitializeComponent();
            this.ServiceName = "MusicStoreWindowsService";
        }
        protected override void OnStart(string[] args)
        {
            hosts.ForEach(webServiceHost => webServiceHost.Close());
            hosts.Clear();
            hosts.Add(new WebServiceHost(typeof(EmployeesService)));
            hosts.Add(new WebServiceHost(typeof(WCFAlbumService)));
            hosts.Add(new WebServiceHost(typeof(WCFArtistService)));
            hosts.Add(new WebServiceHost(typeof(WCFGenreService)));
            hosts.Add(new WebServiceHost(typeof(WCFOrderService)));
            hosts.Add(new WebServiceHost(typeof(WCFOrderDetailService)));
            hosts.ForEach(webServiceHost => webServiceHost.Open());
        }
        protected override void OnStop()
        {
            hosts.ForEach(webServiceHost => webServiceHost.Close());
            hosts.Clear();
        }
       
    }
}
