using Microsoft.Owin.Security.OAuth;
using MusicStoreBIL.Services;
using MusicStoreBIL.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MusicStoreRestByWebApi.AuthorizeProvider
{
    /// <summary>
    /// 授权服务提供器
    /// 2017/05/07 fhr
    /// </summary>
    public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //用户服务组件 自定义
        private IUserService userService = new XmlUserServiceClass();
        //客户端服务组件 自定义
        private IClientService clientServce = new XmlClientServiceClass();

        /// <summary>
        /// 验证 client 信息
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
            if (string.IsNullOrEmpty(clientId)||clientSecret != clientServce.FindClientSecret(clientId))
            {
                context.SetError("invalid_client", "client is not valid");
                return;
            }
            //client存在则通过校验
            context.Validated();
        }

        /// <summary>
        /// 授予资源所有者证书
        /// 此方法主要作用：验证用户，通过校验
        /// </summary>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
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
            if (context.Password!=userService.FindUserPassword(context.UserName))
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