using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract.EnableCacheServiceContract
{
    /// <summary>
    /// 带输出缓存的专辑服务契约
    /// 2017/04/20 fhr
    /// AspNetCacheProfile特性表示要对方法结果使用相应输出缓存容器进行缓存
    /// </summary>
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public interface IWCFAlbumService
    {
        [OperationContract]
        [WebGet(UriTemplate = "all")]
        [AspNetCacheProfile("albumCache")]
        [Description("获取所有专辑")]
        IEnumerable<Album> FindAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("albumCache")]
        [Description("获取指定ID的专辑")]
        Album FindOne(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "save", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("创建专辑")]
        Album Create(Album album);

        [OperationContract]
        [WebInvoke(Method = "Put", UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [Description("更新专辑")]
        Album Update(Album album);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [Description("删除专辑")]
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Search?genreId={genreId}&title={title}&minPrice={minPrice}&maxPrice={maxPrice}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [AspNetCacheProfile("albumCache")]
        [Description("查询专辑")]
        IEnumerable<Album> search(int genreId, string title, decimal minPrice =-1, decimal maxPrice=-1);
    }
}
