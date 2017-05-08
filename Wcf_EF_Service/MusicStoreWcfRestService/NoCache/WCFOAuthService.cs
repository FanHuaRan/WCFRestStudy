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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class WCFOAuthService : IWCFOAuthService
    {

        private IUserService userService = new WebApiXmlUserServiceClass();

        private ITokenStoreService tokenServce = new RedisTokenStoreServiceClass();

        private ICreateTokenStrategy tokenCreateStrategy = new SimpleCreateTokenStrategy();
        public object Token(string grant_type, string userName, string password)
        {
            if (grant_type == "password")
            {
                if (string.IsNullOrEmpty(userName))
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                    return new OAuthError("invalid_granttype", "granttype is invalid");
                }
                if (password != userService.FindUserPassword(userName))
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                    return new OAuthError("invalid_granttype", "granttype is invalid");
                }
                var oauthEntity = tokenServce.FindOAuthEntityByUsername(userName);
                if (oauthEntity == null)
                {
                    oauthEntity = createOAuthEntity(oauthEntity);
                }
                return oauthEntity;
            }
            else if (grant_type == "refresh_token")
            {
                //////////
                return null;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return new OAuthError("invalid_granttype", "granttype is invalid");
            }
        }

        private OAuthEntity createOAuthEntity(OAuthEntity oauthEntity)
        {
            var access_Token = tokenCreateStrategy.CreateAccessToken();
            var refresn_Token = tokenCreateStrategy.createRefreshToken();
            oauthEntity = new OAuthEntity(access_Token, refresn_Token, 43199);
            return oauthEntity;
        }
    }
}
