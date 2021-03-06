﻿using MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestByWindowsServiceHost
{
    /// <summary>
    /// MusicStore的Windows服务
    /// 2017/04/28 fhr
    /// ServiceBase为windows服务基类
    /// </summary>
    public class MusicStoreWindowsService : ServiceBase
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
        public static void Main(string[] args)
        {
            ServiceBase.Run(new MusicStoreWindowsService());
        }
    }
}
