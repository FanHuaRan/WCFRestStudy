using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestByWin
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    //添加对实现对ASP.NET兼容模式的支持，从而可以使用asp.net相关机制：HttpContext的请求下下文；基于文件或者Url的授权；HttpModule扩展；身份模拟（Impersonation）等
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    //服务示例为单例 多线程
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WcfEfRestService : IWcfEfRestService
    {
        //可以使用WebGet、WebInvoke甚至是WebHttpBinding来暴露
        //这些属性每一个都确定HTTP动作、消息格式以及需要暴露给一个操作的消息体形式。
        //类似于spring mvc @requestmapping
        [WebInvoke(Method = "GET", UriTemplate = "GetData/{name}/{value}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetData(string name, string value)
        {
            return string.Format(" {0}: {1}",name, value);
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetUserData", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public List<User> GetUserData()
        {
            List<User> Ls = new List<User>(); 
            User usr = new User();
            usr.Name = "MMM";
            usr.age = 35;
            Ls.Add(usr);
            User usr1 = new User();
            usr1.Name = "XXX";
            usr1.age = 38;
            Ls.Add(usr1);
            return Ls;
        }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public int age { set; get; }

    }

}
