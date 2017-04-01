using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfRestByWin
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(Namespace = "http://www.priest119.com")]
    public interface IWcfEfRestService
    {
        [OperationContract]
        string GetData(string name, string value);

        [OperationContract]
        List<User> GetUserData();

        // TODO: 在此添加您的服务操作
    }

  }
