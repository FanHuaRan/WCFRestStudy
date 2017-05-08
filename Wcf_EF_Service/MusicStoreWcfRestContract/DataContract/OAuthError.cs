using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// OAuth授权错误消息
    /// 2017/05/08 fhr
    /// </summary>
    [DataContract]
    public class OAuthError
    {
        [DataMember(Name = "error")]
        public string Error { get; set; }

        [DataMember(Name = "error_description")]
        public string Description { get; set; }

        public OAuthError(string error, string description)
        {
            this.Error = error;
            this.Description = description;
        }
    }
}
