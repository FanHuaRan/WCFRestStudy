using Microsoft.Owin.Security.OAuth;
using MusicStoreBIL.Services;
using MusicStoreBIL.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MusicStoreRestByWebApi.Auth
{
    /// <summary>
    /// 基于密码和客户端授权的OAuth授权服务器
    /// 这里模仿Spring-Security-OAuth2,同时使用客户端和密码授权
    /// 实际运行时：先运行ValidateClientAuthentication 后运行GrantResourceOwnerCredentials
    /// 2017/05/07 fhr
    /// </summary>
    public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //用户服务组件 自定义
        private IUserService userService = new WebApiXmlUserServiceClass();

        //客户端服务组件 自定义
        private IClientService clientServce = new WebApiXmlClientServiceClass();

        /// <summary>
        /// 验证 client 信息
        /// 如果此方法不进行客户端校验，只依靠下面的校验，则为单纯的密码授权
        /// </summary>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //从用户的请求参数中获取clientId与clientsecret
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
            //验证client是否存在
            if (string.IsNullOrEmpty(clientId) || clientSecret != await clientServce.FindClientSecretAsync(clientId))
            {
                context.SetError("invalid_client", "client is not valid");
                return;
            }
            //client存在则通过校验
            context.Validated();
        }

        /// <summary>
        /// 授予资源所有者证书
        /// 此方法主要作用：验证用户，生成初始的access_token
        /// 如果此方法不进行用户校验，只依靠上面方法的校验，即只是单纯的客户端授权
        /// </summary>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //令牌中间件提供者允许CORS
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //验证用户名和密码
            if (string.IsNullOrEmpty(context.UserName))
            {
                context.SetError("invalid_username", "username is not valid");
                return;
            }
            if (string.IsNullOrEmpty(context.Password))
            {
                context.SetError("invalid_password", "password is not valid");
                return;
            }
            if (context.Password!=await userService.FindUserPasswordAsync(context.UserName))
            {
                context.SetError("invalid_identity", "username or password is not valid");
                return;
            }
            var OAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            //通过校验
            context.Validated(OAuthIdentity);
        }
    }
}