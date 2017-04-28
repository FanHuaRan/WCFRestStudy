using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 艺术家服务契约
    /// 2017/04/01 fhr
    /// </summary>
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFArtistService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("获取所有艺术家")]
        IEnumerable<Artist> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("获取指定ID的艺术家")]
        Artist FindById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "searchbyname/{name}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("根据Name获取艺术家")]
        IEnumerable<Artist> FindByName(string name);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("保存艺术家")]
        Artist Save(Artist artist);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("更新艺术家")]
        Artist Update(string id,Artist artist);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("删除艺术家")]
        void Delete(string id);
    }
}
