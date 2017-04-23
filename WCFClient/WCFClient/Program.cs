using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            testWCFCache();
            Console.ReadLine();
        }
        /// <summary>
        /// 对我们的WCF REST服务进行测试
        /// </summary>
        private static void testWCFCache()
        {
            //因为缓存时间设置的60s,所以在此进行11次访问，
            //每次访问后都把线程阻塞6s,让我们能够在第11次看到过期的效果
            for (int i = 0; i < 11; i++)
            {
                var startTime=DateTime.Now;
                //为了防止HttpClient预热的影响，我们每次都实例化HttpClient对象
                using (var httpClient = new HttpClient())
                {
                    var respone = httpClient.GetAsync(@"http://localhost:64032/Albums/all").Result;
                }
                var endTime=DateTime.Now;
                Console.WriteLine(string.Format("第{0}次请求耗时：{1}",i+1,endTime - startTime));
                Thread.Sleep(6000);
            }
        }
    }
}
