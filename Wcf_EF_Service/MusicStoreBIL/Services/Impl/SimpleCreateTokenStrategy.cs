using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;  
namespace MusicStoreBIL.Services.Impl
{
    /// <summary>
    /// 简易token生成策略 直接通过UUID进行MD5摘要而生成
    /// 2017/05/08 fhr
    /// </summary>
    public class SimpleCreateTokenStrategy : ICreateTokenStrategy
    {
        private MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
        public string CreateAccessToken()
        {
            return creatTokenByUUIDMD5();
        }

        public string createRefreshToken()
        {
            return creatTokenByUUIDMD5();
        }

        private string creatTokenByUUIDMD5()
        {
            var guid = new Guid();
            var bytes = Encoding.Default.GetBytes(guid.ToString());
            var result = BitConverter.ToString(md5CryptoServiceProvider.ComputeHash(bytes));
            return result;
        }
    }
}
