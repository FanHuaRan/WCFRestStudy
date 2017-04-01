using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace WcfRestByWeb
{
    [ServiceContract(Namespace = "http://www.priest119.com")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WcfEfRestService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetData/{name}/{value}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetData(string name, string value)
        {
            return string.Format(" {0}: {1}", name, value);
        }
      
        [OperationContract]
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
