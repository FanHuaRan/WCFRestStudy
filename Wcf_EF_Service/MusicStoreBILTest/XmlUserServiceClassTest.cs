using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStoreBIL.Services;
using MusicStoreBIL.Services.Impl;

namespace MusicStoreBILTest
{
    [TestClass]
    public class XmlUserServiceClassTest
    {
        private IUserService userServioce = new XmlUserServiceClass();
        [TestMethod]
        public void TestFindUserRole()
        {
            var role=userServioce.FindUserRole("Admin");
            Assert.AreEqual("Admin", role);
        }
        [TestMethod]

        public void TestFindUserPassword()
        {
            var password = userServioce.FindUserPassword("Tom");
            Assert.AreEqual("123", password);
        }
        [TestMethod]

        public void TestSaveUser()
        {
            Assert.IsTrue(userServioce.SaveUser("fhr", "123", "User"));
            var role = userServioce.FindUserRole("fhr");
            Assert.AreEqual("User", role);
        }
    }
}
