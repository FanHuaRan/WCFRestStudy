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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFOrderDetailService : cache.IWCFOrderDetailService
    {
        private IWCFOrderDetailService orderDetailServiceDelegate = new MusicStoreWcfRestService.WCFOrderDetailService();

        public void Delete(string id)
        {
            orderDetailServiceDelegate.Delete(id);
        }

        public IEnumerable<OrderDetail> FindAll()
        {
            return orderDetailServiceDelegate.FindAll();
        }

        public OrderDetail FindById(string id)
        {

            return orderDetailServiceDelegate.FindById(id);
        }

        public OrderDetail Save(OrderDetail order)
        {
            return orderDetailServiceDelegate.Save(order);
        }

        public OrderDetail Update(string id, OrderDetail order)
        {
            return orderDetailServiceDelegate.Update(id, order);
        }

        public IEnumerable<OrderDetail> search(string albumId, string orderId)
        {

            return orderDetailServiceDelegate.search(albumId, orderId);
        }
    }
}
