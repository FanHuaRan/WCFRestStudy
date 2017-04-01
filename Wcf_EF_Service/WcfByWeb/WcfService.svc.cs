using BLL;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DAL.EF;

namespace WcfByWeb
{
    [ServiceContract(Namespace = "http://www.baidu.com")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfService
    {
        #region 用户管理

        [OperationContract]
        public userinfo login(string name,string pwd)
        {
            return UserManager.Login(name,pwd);
        }


        [OperationContract]
        public void AddUser()
        {
            // 在此处添加操作实现
            return;
        }

        [OperationContract]
        public void UpdateUser()
        {
            // 在此处添加操作实现
            return;
        }


        [OperationContract]
        public void GetUser()
        {
            // 在此处添加操作实现
            return;
        }

        [OperationContract]
        public void DelUser()
        {
            // 在此处添加操作实现
            return;
        } 

        #endregion
    }
}
