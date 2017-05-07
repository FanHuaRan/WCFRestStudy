using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Services
{
    /// <summary>
    /// 客户端信息服务接口
    /// 2017/05/05 fhr
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// 根据clientId查询clientSecret
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        string FindClientSecret(string clientId);

        /// <summary>
        /// 根据clientId查询clientSecret 可异步
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<string> FindClientSecretAsync(string clientId);

        /// <summary>
        /// 保存客户端信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        bool SaveClient(string clientId, string clientSecret);

        /// <summary>
        /// 保存客户端信息 可异步
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        Task<bool> SaveClientAsync(string clientId, string clientSecret);

    }
}
