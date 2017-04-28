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
    /// 订单条目服务契约
    /// 2017/04/01 fhr
    /// </summary>
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFOrderDetailService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("获取所有订单条目")]
        IEnumerable<OrderDetail> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("获取指定ID的订单条目")]
        OrderDetail FindById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("保存订单条目")]
        OrderDetail Save(OrderDetail order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("更新订单条目")]
        OrderDetail Update(string id,OrderDetail order);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("根据ID删除条目")]
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "search?albumId={albumId}&orderId={orderId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("查询订单条目")]
        IEnumerable<OrderDetail> search(string albumId, string orderId);
    }
}
