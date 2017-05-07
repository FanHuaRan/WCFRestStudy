using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Services
{
    /// <summary>
    /// 客户端服务接口
    /// 2017/05/05 fhr
    /// </summary>
    public interface IClientService
    {
        string FindClientSecret(string clientId);
        bool SaveClient(string clientId, string clientSecret);
    }
}
