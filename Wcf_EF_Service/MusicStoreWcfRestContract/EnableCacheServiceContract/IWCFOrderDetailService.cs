using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract.EnableCacheServiceContract
{
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFOrderDetailService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("orderDetailCache")]
        IEnumerable<OrderDetail> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("orderDetailCache")]
        OrderDetail FindById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        OrderDetail Save(OrderDetail order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        OrderDetail Update(string id,OrderDetail order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "search?albumId={albumId}&orderId={orderId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("orderDetailCache")]
        IEnumerable<OrderDetail> search(string albumId, string orderId);
    }
}
