using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EF;

namespace BLL
{
    public class UserManager
    {
        public static userinfo Login(string name,string pwd) {

            return UserDAL.Login(name,pwd);
        }

        public static bool AddUser(userinfo u)
        {
            return UserDAL.AddUser(u);
        }
    }
}
