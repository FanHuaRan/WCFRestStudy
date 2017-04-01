using System;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using System.ServiceModel;
using WcfByWin;

namespace BQKJServer.ServerGuid
{
    static partial class Program
    {
        public static string ServiceName = ConfigurationManager.AppSettings["ServiceName"].ToString();
        public static string Description = ConfigurationManager.AppSettings["ServiceDescription"].ToString();

        static void Main(string[] args)
        {     
            #region Windows 服务启动
            if (!Environment.UserInteractive || !AppDomain.CurrentDomain.FriendlyName.Equals(Path.GetFileName(Assembly.GetEntryAssembly().CodeBase)))
            {
                RunAsService();
                return;
            } 
            #endregion

            #region 服务安装与卸载
            if (args != null && args.Length > 0)
            {
                if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                {
                    SelfInstaller.InstallMe();
                    return;
                }
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
             
        private static void RunAsService()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[] { new MainService() };
            ServiceBase.Run(servicesToRun);
        }
  }
}