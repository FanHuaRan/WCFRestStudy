using MusicStoreBIL.Services;
using MusicStoreBIL.Services.Impl;
using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestService
{
    /// <summary>
    /// OAUTH授权服务：密码授权+token刷新
    /// 2017/05/09 fhr
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFOAuthService : IWCFOAuthService
    {

        private IUserService userService = new WebApiXmlUserServiceClass();

        private ITokenStoreService tokenService = new RedisTokenStoreServiceClass();

        private ICreateTokenStrategy tokenCreateStrategy = new SimpleCreateTokenStrategy();
        public OAuthBaseModel Token(string grant_type, string userName, string password,string refreshToken)
        {
            //密码授权方式
            if (grant_type == "password")
            {
                return PasswordGrant(userName, password);
            }
            //token刷新
            else if (grant_type == "refresh_token")
            {
                return RefreshTokenGrant(refreshToken);
            }
            //暂时不支持其它授权方式
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return new OAuthError("invalid_granttype", "granttype is invalid");
            }
        }
        /// <summary>
        /// 处理密码授权
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private OAuthBaseModel PasswordGrant(string userName,string password)
        {
            if (string.IsNullOrEmpty(userName)||password != userService.FindUserPassword(userName))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return new OAuthError("invalid_user", "user is invalid");
            }
            var oauthEntity = tokenService.FindOAuthEntityByUsername(userName);
            if (oauthEntity == null)
            {
                oauthEntity = CreateOAuthEntity(userName, password);
                SaveToStore(oauthEntity);
            }
            return oauthEntity;
        }
        /// <summary>
        /// 处理token刷新
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        private OAuthBaseModel RefreshTokenGrant(string refreshToken)
        {
            var oauthEntity = tokenService.FindOAuthEntityByRefeshToken(refreshToken);
            if (oauthEntity == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return new OAuthError("invalid_refeshToken", "refeshToken is invalid");
            }
            RemoveOauthFromStore(refreshToken, oauthEntity);
            oauthEntity = CreateOAuthEntity(oauthEntity.UserName, oauthEntity.Password);
            SaveToStore(oauthEntity);
            return oauthEntity;
        }
        /// <summary>
        /// 保存oauthEntity
        /// </summary>
        /// <param name="oauthEntity"></param>
        private void SaveToStore(OAuthEntity oauthEntity)
        {
            tokenService.SaveUserName_OAuthEntity(oauthEntity.UserName, oauthEntity);
            tokenService.SaveAccessToken(oauthEntity.Access_Token, oauthEntity);
            tokenService.SaveRefreshToken(oauthEntity.Refresh_Token, oauthEntity);
        }
        /// <summary>
        /// 创建oauthEntity
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private OAuthEntity CreateOAuthEntity(string userName,string password)
        {
            var access_Token = tokenCreateStrategy.CreateAccessToken();
            var refresn_Token = tokenCreateStrategy.createRefreshToken();
            var oauthEntity = new OAuthEntity(access_Token, refresn_Token, 43199,userName,password);
            return oauthEntity;
        }
        /// <summary>
        /// 服务器中移除oauthEntity
        /// </summary>
        /// <param name="refeshToken"></param>
        /// <param name="oauthEntity"></param>
        private void RemoveOauthFromStore(string refeshToken, OAuthEntity oauthEntity)
        {
            tokenService.RemoveRefreshToken(refeshToken);
            tokenService.ReomveAccessToken(oauthEntity.Access_Token);
            tokenService.ReomveUserName_OAuthEntity(oauthEntity.UserName);
        }

    }
}
