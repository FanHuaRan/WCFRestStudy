using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 订单服务契约
    /// 2017/04/01 fhr
    /// </summary>
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFOrderService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("获取所有订单")]
        IEnumerable<Order> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("获取指定ID的订单")]
        Order FindById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("保存订单")]
        Order Save(Order order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("更新订单")]
        Order Update(string id,Order order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("根据ID删除订单")]
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "search?username={userName}&city={city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("查询订单")]
        IEnumerable<Order> search(string userName, string city);
    }
}
