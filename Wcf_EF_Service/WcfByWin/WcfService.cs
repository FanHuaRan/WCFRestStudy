using BLL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfByWin
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class WcfService : IWcfService
    {

        #region 用户管理

        public userinfo login(string name, string pwd)
        {
            return UserManager.Login(name, pwd);
        }

        public bool AddUser(userinfo u)
        {
            // 在此处添加操作实现
            return UserManager.AddUser(u);
        }

        public bool UpdateUser()
        {
            // 在此处添加操作实现
            bool r = false;
            return r;
        }

        public List<userinfo> GetUserList()
        {
            // 在此处添加操作实现
            List<userinfo> lst = new List<userinfo>() ;
            return lst;
        }

        public bool DelUser()
        {
            // 在此处添加操作实现
            bool r = false;
            return r;
        }

        #endregion

    }
}
