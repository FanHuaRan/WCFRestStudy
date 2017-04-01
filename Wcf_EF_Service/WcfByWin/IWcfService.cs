using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfByWin
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IWcfService
    {
        #region 用户管理

        [OperationContract]
        userinfo login(string name, string pwd);

        [OperationContract]
        bool AddUser(userinfo u);

        [OperationContract]
        bool UpdateUser();

        [OperationContract]
        List<userinfo> GetUserList();

        [OperationContract]
        bool DelUser();

        #endregion
    }
}
