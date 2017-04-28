using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 雇员服务契约
    /// 作者：cnblogs->artech
    /// </summary>
    [ServiceContract]
    public interface IEmployeesService
    {
        // 要使用 HTTP GET，请添加 [WebGet] 特性。(默认 ResponseFormat 为 WebMessageFormat.Json)
        // 要创建返回 XML 的操作，
        //     请添加 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
        //     并在操作正文中包括以下行:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        [OperationContract]
        [WebGet(UriTemplate = "all")]
        [Description("获取所有员工列表")]
        IEnumerable<Employee> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        [Description("获取指定ID的员工")]
        Employee Get(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/", Method = "POST")]
        [Description("创建一个新的员工")]
        void Create(Employee employee);

        [OperationContract]
        [WebInvoke(UriTemplate = "/", Method = "PUT")]
        [Description("修改现有员工信息")]
        void Update(Employee employee);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        [Description("删除指定ID的员工")]
        void Delete(string id);
    }
}
