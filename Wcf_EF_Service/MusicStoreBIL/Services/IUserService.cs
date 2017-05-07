using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreBIL.Services
{
    /// <summary>
    /// 用户信息服务接口
    /// 2017/05/05 fhr
    /// </summary>
    public interface IUserService
    {
        string FindUserRole(string userName);

        Task<string> FindUserRoleAsync(string userName);

        string FindUserPassword(string userName);

        Task<string> FindUserPasswordAsync(string userName);

        bool SaveUser(string userName, string password, string role);

        Task<bool> SaveUserAsync(string userName, string password, string role);

    }
}
