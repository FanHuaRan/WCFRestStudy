using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.Net;
using MusicStoreBIL.Daos;
using MusicStoreUtils;
namespace MusicStoreWcfRestService
{
    /// <summary>
    /// 订单条目服务实现
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFOrderDetailService : IWCFOrderDetailService
    {
        private OrderDetailDao orderDetailDao = new OrderDetailDao();
        public void Delete(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                orderDetailDao.DeleteById(realId);
            }
        }

        public IEnumerable<OrderDetail> FindAll()
        {
            return orderDetailDao.FindAll();
        }

        public OrderDetail FindById(string id)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            else
            {
                return orderDetailDao.FindById(realId);
            }
        }

        public OrderDetail Save(OrderDetail order)
        {
            if (EntityValidatorUtil.Validate<OrderDetail>(order))
            {
                return orderDetailDao.Save(order);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public OrderDetail Update(string id, OrderDetail order)
        {
            Int32 realId;
            if (!Int32.TryParse(id, out realId))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
            if (EntityValidatorUtil.Validate<OrderDetail>(order))
            {
                return orderDetailDao.Save(order);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
        }

        public IEnumerable<OrderDetail> search(string albumId, string orderId)
        {
            if (albumId == null && orderId == null)
            {
                return new List<OrderDetail>();
            }
            Int32 realAlbumId, realOrderId;
            if ((!Int32.TryParse(albumId, out realAlbumId) && albumId != null)
                || (!Int32.TryParse(orderId, out realOrderId) && orderId != null))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }
            else
            {
               return orderDetailDao.SimpleCompositeFind(getCondtions(albumId, orderId, realAlbumId, realOrderId).ToArray());
            }
        }

        private static List<Func<OrderDetail, bool>> getCondtions(string albumId, string genreId, Int32 realAlbumId, Int32 realOrderId)
        {
            var conditions = new List<Func<OrderDetail, bool>>();
            if (albumId != null)
            {
                conditions.Add(orderDetail => orderDetail.AlbumId == realAlbumId);
            }
            if (genreId != null)
            {
                conditions.Add(orderDetail => orderDetail.OrderId == realOrderId);
            }
            return conditions;
        }
    }
}
