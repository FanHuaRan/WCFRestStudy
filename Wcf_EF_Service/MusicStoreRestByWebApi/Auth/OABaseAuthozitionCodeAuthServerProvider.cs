using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using MusicStoreBIL.Services;
using MusicStoreBIL.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace MusicStoreRestByWebApi.Auth
{
    /// <summary>
    /// 基于授权码和简化模式的授权服务器实现
    /// 注意:这儿不需要用户参与
    /// 2017/05/07 fhr
    /// </summary>
    public class OABaseAuthozitionCodeAuthServerProvider : OAuthAuthorizationServerProvider
    {
        private IClientService clientService = new WebApiXmlClientServiceClass();
        /// <summary>
        /// 验证 client 信息
        /// </summary>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (clientId == null || clientSecret != clientService.FindClientSecret(clientId))
            {
                context.SetError("invalid_client", "client is not valid");
                return;
            }
            context.Validated();
        }

        /// <summary>
        /// 生成 authorization_code（authorization code 授权方式）、生成 access_token （implicit 授权模式）
        /// </summary>
        public override async Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            //简化模式
            if (context.AuthorizeRequest.IsImplicitGrantType)
            {
                var identity = new ClaimsIdentity("Bearer");
                context.OwinContext.Authentication.SignIn(identity);
                context.RequestCompleted();
            }
            //authorization code 授权方式
            else if (context.AuthorizeRequest.IsAuthorizationCodeGrantType)
            {
                var redirectUri = context.Request.Query["redirect_uri"];
                var clientId = context.Request.Query["client_id"];
                var identity = new ClaimsIdentity(new GenericIdentity(clientId, OAuthDefaults.AuthenticationType));
                var authorizeCodeContext = new AuthenticationTokenCreateContext(
                    context.OwinContext,
                    context.Options.AuthorizationCodeFormat,
                    new AuthenticationTicket(identity,
                        new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {"client_id", clientId},
                            {"redirect_uri", redirectUri}
                        })
                        {
                            IssuedUtc = DateTimeOffset.UtcNow,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(context.Options.AuthorizationCodeExpireTimeSpan)
                        }));
                await context.Options.AuthorizationCodeProvider.CreateAsync(authorizeCodeContext);
                context.Response.Redirect(redirectUri + "?code=" + Uri.EscapeDataString(authorizeCodeContext.Token));
                context.RequestCompleted();
            }
        }
    }
}