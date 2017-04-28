using MusicStoreWcfRestContract;
using cache = MusicStoreWcfRestContract.EnableCacheServiceContract;
using baseService = MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.Net;
namespace MusicStoreWcfRestService.EnableCache
{
    /// <summary>
    /// 带输出缓存的订单服务实现
    /// 2017/04/22 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFOrderService : cache.IWCFOrderService
    {
        private IWCFOrderService orderServiceDelegate = new MusicStoreWcfRestService.WCFOrderService();

        public void Delete(string id)
        {
            orderServiceDelegate.Delete(id);
        }

        public IEnumerable<Order> FindAll()
        {
            return orderServiceDelegate.FindAll();
        }

        public Order FindById(string id)
        {
            return orderServiceDelegate.FindById(id);
        }

        public Order Save(Order order)
        {
            return orderServiceDelegate.Save(order);
        }

        public Order Update(string id, Order order)
        {
            return orderServiceDelegate.Update(id,order);
        }

        public IEnumerable<Order> search(string userName, string city)
        {
            return orderServiceDelegate.search(userName, city);
        }
    }
}
