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
        [WebGet(UriTemplate = "all")]
        IEnumerable<Employee> GetAll();

        [WebGet(UriTemplate = "{id}")]
        Employee Get(string id);

        [WebInvoke(UriTemplate = "/", Method = "POST")]
        void Create(Employee employee);

        [WebInvoke(UriTemplate = "/", Method = "PUT")]
        void Update(Employee employee);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }
}
