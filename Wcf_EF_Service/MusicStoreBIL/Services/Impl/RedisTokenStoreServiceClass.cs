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
    /// 有问题 在同一个容器中key-value存储有可能冲突 暂时不改了
    /// 2017/05/09 fhr
    /// </summary>
    public class RedisTokenStoreServiceClass : ITokenStoreService
    {
        private static RedisClient redisClient = new RedisClient("101.200.55.205", 6379, "12345678");
        
        public bool SaveUserName_OAuthEntity(string userName, OAuthEntity oauthEntity)
        {
            try
            {
                //12h
                return redisClient.Set<OAuthEntity>(userName, oauthEntity, TimeSpan.FromHours(12));
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
                //12h
                return redisClient.Set<OAuthEntity>(accessToken, oauthEntity, TimeSpan.FromHours(12));
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
                return redisClient.Set<OAuthEntity>(refeshToken, oauthEntity);
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


        public bool ReomveUserName_OAuthEntity(string userName)
        {
           return redisClient.Remove(userName);
        }

        public bool ReomveAccessToken(string accessToken)
        {
            return redisClient.Remove(accessToken);
        }

        public bool RemoveRefreshToken(string refeshToken)
        {
            return redisClient.Remove(refeshToken);
        }
    }
}
