using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using MusicStoreUtils;
using MusicStoreBIL.Daos;
using System.Net;
namespace MusicStoreWcfRestService
{
    /// <summary>
    /// 订单服务实现
    /// 2017/04/05 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFOrderService : IWCFOrderService
    {
        private OrderDao orderDao = new OrderDao();
        public void Delete(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                orderDao.DeleteById(realId);
            }
        }

        public IEnumerable<Order> FindAll()
        {
            return orderDao.FindAll();
        }

        public Order FindById(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return orderDao.FindById(realId);
            }
        }

        public Order Save(Order order)
        {
            if (EntityValidatorUtil.Validate<Order>(order))
            {
                return orderDao.Save(order);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public Order Update(string id, Order order)
        {
             Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            if (EntityValidatorUtil.Validate<Order>(order))
            {
                return orderDao.Save(order);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public IEnumerable<Order> search(string userName, string city)
        {
            return orderDao.FindByLinq(p => p.Username == userName && p.City == city);
        }
    }
}
