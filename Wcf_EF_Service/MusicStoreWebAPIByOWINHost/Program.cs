using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWebAPIByOWINHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用WebApp根据Startup开启服务
            using (WebApp.Start<Startup>("http://localhost:18081"))
            {
                Console.WriteLine("api server is listening http://localhost:18081 ");
                Console.WriteLine("enter to exit");
                Console.ReadLine();
            }
        }
    }
}
