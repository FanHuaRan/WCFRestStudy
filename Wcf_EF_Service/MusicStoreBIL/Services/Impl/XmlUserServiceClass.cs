using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicStoreBIL.Services.Impl
{
    /// <summary>
    /// 用户服务的xml存储实现
    /// 2017/05/05 fhr
    /// </summary>
    public class XmlUserServiceClass:IUserService
    {
        private object locker=new object();
        private static readonly string XMLUSERFILENAME = "musicstore-users.xml";
        private static readonly ILog log = LogManager.GetLogger(typeof(XmlUserServiceClass));
        public  string FindUserRole(string userName)
        {
            lock (locker)
            {
                try
                {
                    var document = createXmlDocument();
                    var userNodeList = document.SelectNodes("users/user");
                    foreach (XmlNode userNode in userNodeList)
                    {
                        var uName = userNode.Attributes["username"].Value;
                        if (uName == userName)
                        {
                            return userNode.Attributes["role"].Value;
                        }
                    }
                }
                catch (Exception e)
                {
                    log.Error("FindUserRole wrong", e);
                }
                return null;
            }
        }
        public string FindUserPassword(string userName)
        {
            lock (locker)
            {
                try
                {
                    var document = createXmlDocument();
                    var userNodeList = document.SelectNodes("users/user");
                    foreach (XmlNode userNode in userNodeList)
                    {
                        var uName = userNode.Attributes["username"].Value;
                        if (uName == userName)
                        {
                            return userNode.Attributes["password"].Value;
                        }
                    }
                }
                catch (Exception e)
                {
                    log.Error("FindUserPassword wrong", e);
                }
                return null;
            }
        }
        public bool SaveUser(string userName, string password, string role)
        {
            lock (locker)
            {
                if (FindUserPassword(userName) != null)
                {
                    return false;
                }
                try
                {
                    var document = createXmlDocument();
                    var rootNode = document.SelectSingleNode("users");
                    var userElement = createUserElement(userName, password, role, document);
                    rootNode.AppendChild(userElement);
                    document.Save(XMLUSERFILENAME);
                    return true;
                }
                catch (Exception e)
                {
                    log.Error("SaveUser wrong", e);
                    return false;
                }
            }
        }

        private static XmlElement createUserElement(string userName, string password, string role, XmlDocument document)
        {
            var userElement = document.CreateElement("user");
            var nameAttri = document.CreateAttribute("username");
            nameAttri.Value = userName;
            var passwordAttri = document.CreateAttribute("password");
            passwordAttri.Value = password;
            var roleAttri = document.CreateAttribute("role");
            roleAttri.Value = role;
            userElement.Attributes.Append(nameAttri);
            userElement.Attributes.Append(passwordAttri);
            userElement.Attributes.Append(roleAttri);
            return userElement;
        }
        private XmlDocument createXmlDocument()
        {
            var docMent = new XmlDocument();
            docMent.Load(XMLUSERFILENAME);
            return docMent;
        }
    }
}
