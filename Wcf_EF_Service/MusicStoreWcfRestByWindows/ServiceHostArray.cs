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
    /// ServiceHost集合 实现了资源释放接口
    /// 2017/04/28 fhr
    /// </summary>
    public class ServiceHostArray : IDisposable
    {
        private IEnumerable<WebServiceHost> serviceHosts = null;

        public IEnumerable<WebServiceHost> ServiceHosts
        {
            get { return serviceHosts; }
            set { serviceHosts = value; }
        }
        public void Open()
        {
            foreach (var host in serviceHosts)
            {
                if (host.State == CommunicationState.Closed)
                {
                    host.Open();
                }
            }
        }
        public void Close()
        {
            foreach (var host in serviceHosts)
            {
                if (host.State == CommunicationState.Opened)
                {
                    host.Open();
                }
            }
        }
        public void Dispose()
        {
            this.Close();
        }
    }
}
