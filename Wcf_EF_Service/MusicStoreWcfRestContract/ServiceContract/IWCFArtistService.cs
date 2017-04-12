using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFArtistService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Artist> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Artist FindById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "searchbyname/{name}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Artist> FindByName(string name);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Artist Save(Artist artist);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Artist Update(string id,Artist artist);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void Delete(string id);
    }
}
