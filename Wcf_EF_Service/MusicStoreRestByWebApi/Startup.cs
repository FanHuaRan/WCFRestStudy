using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using MusicStoreRestByWebApi.Auth;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
[assembly: OwinStartup(typeof(MusicStoreRestByWebApi.Startup))]
namespace MusicStoreRestByWebApi
{
    /// <summary>
    /// 只能再startup.cs中配置OAuth,放弃Gloabl
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        /// <summary>
        /// 配置OAuth
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/token"), //获取 access_token授权服务请求地址
                AuthorizeEndpointPath = new PathString("/authorize"), //获取 authorization_code授权服务请求地址
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(12), //access_token过期时间
                Provider = new OpenAuthorizationServerProvider(), //access_token 相关授权服务
               // AuthorizationCodeProvider = new OpenAuthorizationCodeProvider(), //authorization_code 授权服务
                RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 授权服务
            };
            app.UseOAuthBearerTokens(OAuthOptions); //表示 token_type 使用 bearer 方式
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
