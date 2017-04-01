using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserDAL
    {
        public static userinfo Login(string name, string pwd)
        {
            userinfo result = null;
            try
            {
                using (testEntities testDb = new testEntities())
                {
                    var us = from c in testDb.userinfoes
                             where c.userid == name && c.password == pwd
                             select c;
                    if (us != null && us.Count() > 0) result = us.First();
                }
            }
            catch (Exception)
            { }
            return result;
        }

        public static bool AddUser(userinfo u)
        {
            bool result = false;
            try
            {
                using (testEntities testDb = new testEntities())
                {
                    testDb.userinfoes.Add(u);
                    testDb.SaveChanges();
                }
                result = true;
            }
            catch (Exception)
            { }
            return result;
        }
    }
}
