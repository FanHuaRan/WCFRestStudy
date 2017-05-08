using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Services
{
    /// <summary>
    /// Token生成策略
    /// 2017/05/08 fhr
    /// </summary>
    public interface ICreateTokenStrategy
    {
        /// <summary>
        /// AccessToken生成
        /// </summary>
        /// <returns></returns>
         string CreateAccessToken();
        /// <summary>
         /// RefreshToken生成
        /// </summary>
        /// <returns></returns>
         string createRefreshToken();
    }
}
