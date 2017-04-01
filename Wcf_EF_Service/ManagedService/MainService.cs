using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using WcfByWin;

namespace BQKJServer.ServerGuid
{
    partial class MainService : ServiceBase
    {
        ServiceHost host;
        public MainService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Type serviceType = typeof(WcfService);//托管REST或非REST服务，方式一样。
            host = new ServiceHost(serviceType);
            host.Open();
        }

        protected override void OnStop()
        {
            if(host != null)
               host.Close();
        }      

    }
}
