using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// OAuth授权实体
    /// 2017/05/08 fhr
    /// </summary>
    [DataContract]
    public class OAuthEntity : OAuthBaseModel
    {
        [DataMember(Name = "access_token")]
        public string Access_Token { get; set; }

        [DataMember(Name = "refresh_token")]
        public string Refresh_Token { get; set; }

        [DataMember(Name = "expires_in")]
        public int Expires_In { get; set; }

        public OAuthEntity(string access_token, string refresh_token, int expires_in,string userName,string password)
        {
            this.Access_Token = access_token;
            this.Refresh_Token = refresh_token;
            this.Expires_In = expires_in;
            this.UserName = userName;
            this.Password = password;
        }
        public OAuthEntity(string access_token, string refresh_token, int expires_in)
            :this(access_token,refresh_token,expires_in,null,null)
        {

        }

    }
}
