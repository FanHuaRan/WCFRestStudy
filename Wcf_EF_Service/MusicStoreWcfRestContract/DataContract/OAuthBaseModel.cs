using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// OAuth授权实体基类
    /// </summary>
    [DataContract]
    public class OAuthBaseModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
