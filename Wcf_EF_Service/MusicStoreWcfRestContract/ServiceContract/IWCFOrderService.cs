using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFOrderService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Order> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Order FindById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Order Save(Order order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Order Update(string id,Order order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "search?username={userName}&city={city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Order> search(string userName, string city);
    }
}
