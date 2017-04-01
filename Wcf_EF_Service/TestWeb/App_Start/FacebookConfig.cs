using System;
using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook;
using Microsoft.AspNet.Mvc.Facebook.Authorization;

namespace TestWeb
{
    public static class FacebookConfig
    {
        public static void Register(FacebookConfiguration configuration)
        {
            // 使用以下应用设置键从 web.config 加载设置:
            // Facebook:AppId, Facebook:AppSecret, Facebook:AppNamespace
            configuration.LoadFromAppSettings();

            // 正在添加授权筛选器以检查 Facebook 签名的请求和权限
            GlobalFilters.Filters.Add(new FacebookAuthorizeFilter(configuration));
        }
    }
}
