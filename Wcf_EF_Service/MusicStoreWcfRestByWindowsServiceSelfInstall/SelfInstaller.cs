using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWcfRestByWindowsServiceSelfInstall
{
    /// <summary>
    /// 调用InstallUtil.exe工具自动安装服务
    /// </summary>
    public class SelfInstaller
    {
        //获取程序exe文件
        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;
        //调用InstallUtil安装服务
        public static bool InstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { _exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }
        //调用installutil卸载服务
        public static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", _exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
