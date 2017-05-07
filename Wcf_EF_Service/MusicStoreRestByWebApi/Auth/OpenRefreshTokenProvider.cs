using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebApi.Auth
{
    /// <summary>
    /// 用于刷新Token的Token提供器
    /// </summary>
    public class OpenRefreshTokenProvider:AuthenticationTokenProvider
    {
        /// <summary>
        /// 注意这儿使用的是线程安全字典 
        /// </summary>
        private static ConcurrentDictionary<string, string> _refreshTokens = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 生成 refresh_token
        /// </summary>
        public override void Create(AuthenticationTokenCreateContext context)
        {
            context.Ticket.Properties.IssuedUtc = DateTime.UtcNow;
            context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddDays(60);

            context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
            _refreshTokens[context.Token] = context.SerializeTicket();
        }

        /// <summary>
        /// 由 refresh_token 解析成 access_token
        /// </summary>
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (_refreshTokens.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }
    }
}