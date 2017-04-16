using System.ServiceProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace MusicStoreWcfRestByWindowsServiceSelfInstall
{
    class Program
    {
        //windows服务名称
        public static readonly string ServiceName = ConfigurationManager.AppSettings["ServiceName"].ToString();
        //windows服务描述
        public static readonly string Description = ConfigurationManager.AppSettings["ServiceDescription"].ToString();
        public static void Main(string[] args)
        {
            #region Windows 服务启动
            //如果当前进程不在用户交互模式或者当前程序域不等于我们的程序
            //则运行windows服务 且直接返回
            if (!Environment.UserInteractive || !AppDomain.CurrentDomain.FriendlyName.Equals(Path.GetFileName(Assembly.GetEntryAssembly().CodeBase)))
            {
                RunServices();
                return;
            }
            #endregion
            #region 服务安装与卸载
            if (args != null && args.Length > 0)
            {
                //控制台参数带-i 安装服务
                if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                {
                    SelfInstaller.InstallMe();
                    return;
                }
                //控制台参数带-u 卸载服务
                else if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase))
                {
                    SelfInstaller.UninstallMe();
                    return;
                }
                Console.WriteLine("Invalid argument!");
                return;
            }
            #endregion
            RunAsConsole();
        }

        private static void RunAsConsole()
        {
            Console.WriteLine("Press key 'q' to stop the Service.");
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                Console.WriteLine();
                continue;
            }
            Console.WriteLine("The  Service has been stopped!");
        }
        //运行服务组件
        private static void RunServices()
        {
            ServiceBase[] servicesToRun = new ServiceBase[]{
                new MusicStoreWindowsService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
