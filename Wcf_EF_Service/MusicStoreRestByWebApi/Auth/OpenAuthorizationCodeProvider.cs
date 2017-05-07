using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreRestByWebApi.Auth
{
    /// <summary>
    /// 基于授权码模式的Token提供器
    /// 2017/05/07 fhr
    /// </summary>
    public class OpenAuthorizationCodeProvider : AuthenticationTokenProvider
    {
        /// <summary>
        /// 注意这儿使用的是线程安全字典 
        /// </summary>
        private readonly ConcurrentDictionary<string, string> _authenticationCodes = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// 生成authorization_code，也就是授权码
        /// </summary>
        public override void Create(AuthenticationTokenCreateContext context)
        {
            context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
            _authenticationCodes[context.Token] = context.SerializeTicket();
        }

        /// <summary>
        /// 由authorization_code解析成access_token
        /// </summary>
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (_authenticationCodes.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }
    }
}