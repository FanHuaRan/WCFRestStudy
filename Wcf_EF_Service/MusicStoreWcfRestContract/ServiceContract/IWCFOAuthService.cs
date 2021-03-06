﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// OAuth授权服务契约
    /// 2017/04/01 fhr
    /// </summary>
    [ServiceContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    [ServiceKnownType(typeof(OAuthEntity))]
    [ServiceKnownType(typeof(OAuthError))]
    public interface IWCFOAuthService
    {
        [OperationContract]
        [WebGet(UriTemplate = "oauth/token?grant_type={grant_type}&username={userName}&password={password}&refesh_token={refreshToken}",
           ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [Description("oauth授权 暂时只基于用户名和密码")]
        OAuthBaseModel Token(string grant_type, string userName, string password, string refreshToken);
    }
}
