using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MusicStoreWcfRestContract
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IEmployeesService”。
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
        IEnumerable<Employee> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Employee Get(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/", Method = "POST")]
        void Create(Employee employee);

        [OperationContract]
        [WebInvoke(UriTemplate = "/", Method = "PUT")]
        void Update(Employee employee);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }
}
