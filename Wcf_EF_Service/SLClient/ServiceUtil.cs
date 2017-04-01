using System;
using System.Windows;
using System.ServiceModel;
using Demo.WcfService;

namespace Demo
{
    public class ServiceUtil
    {
        public static WcfServiceClient GetWcfServiceClient()
       {
            BasicHttpBinding binding = new BasicHttpBinding(
            Application.Current.Host.Source.Scheme.Equals("https", StringComparison.InvariantCultureIgnoreCase)
            ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.None);
            binding.Name = "BasicHttpBinding_WcfService";
            binding.MaxReceivedMessageSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            //==========================================
            binding.TransferMode = TransferMode.Buffered;
            binding.OpenTimeout = new TimeSpan(0,10, 0);
            binding.CloseTimeout = new TimeSpan(0,10, 0);
            binding.SendTimeout = new TimeSpan(0,10, 0);
            binding.ReceiveTimeout = new TimeSpan(0,10, 0);
            //==========================================
            return new WcfServiceClient(binding, new EndpointAddress(new Uri(Application.Current.Host.Source, "../WcfService.svc")));
       }

    }
}
