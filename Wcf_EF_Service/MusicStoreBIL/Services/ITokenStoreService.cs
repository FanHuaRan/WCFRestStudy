using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Services
{
    /// <summary>
    /// Token存储与查询服务
    /// </summary>
    public interface ITokenStoreService
    {

        bool SaveUserName_OAuthEntity(string userName, OAuthEntity oauthEntity);

        bool SaveAccessToken(string accessToken, OAuthEntity oauthEntity);

        bool SaveRefreshToken(string refeshToken, OAuthEntity oauthEntity);

        bool ReomveUserName_OAuthEntity(string userName);

        bool ReomveAccessToken(string accessToken);

        bool RemoveRefreshToken(string refeshToken);

        OAuthEntity FindOAuthEntityByUsername(string userName);

        OAuthEntity FindOAuthEntityByAccessToken(string accessToken);

        OAuthEntity FindOAuthEntityByRefeshToken(string refeshToken);
        
    }
}
