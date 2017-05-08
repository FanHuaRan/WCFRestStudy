using MusicStoreWcfRestContract;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Services.Impl
{
    /// <summary>
    /// Token存储服务的Redis实现
    /// </summary>
    public class RedisTokenStoreServiceClass : ITokenStoreService
    {
        private static RedisClient redisClient = new RedisClient("101.200.55.205", 6379, "12345678");

        public bool SaveUserName_OAuthEntity(string userNmae, OAuthEntity oauthEntity)
        {
            try
            {
                if (redisClient.Add<OAuthEntity>(userNmae, oauthEntity, TimeSpan.FromHours(12)))
                {
                    return false;
                }
                redisClient.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveAccessToken(string accessToken, OAuthEntity oauthEntity)
        {
            try
            {
                if (redisClient.Add<OAuthEntity>(accessToken, oauthEntity, TimeSpan.FromHours(12)))
                {
                    return false;
                }
                redisClient.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveRefreshToken(string refeshToken, OAuthEntity oauthEntity)
        {
            try
            {
                if (redisClient.Add<OAuthEntity>(refeshToken, oauthEntity, TimeSpan.FromHours(12)))
                {
                    return false;
                }
                redisClient.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public OAuthEntity FindOAuthEntityByUsername(string userName)
        {
            return redisClient.Get<OAuthEntity>(userName);
        }

        public OAuthEntity FindOAuthEntityByAccessToken(string accessToken)
        {
            return redisClient.Get<OAuthEntity>(accessToken);
        }

        public OAuthEntity FindOAuthEntityByRefeshToken(string refeshToken)
        {
            return redisClient.Get<OAuthEntity>(refeshToken);
        }
    }
}
