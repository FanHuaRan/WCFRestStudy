using MusicStoreWcfRestContract;
using cache=MusicStoreWcfRestContract.EnableCacheServiceContract;
using baseService=MusicStoreWcfRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MusicStoreWcfRestService.EnableCache
{
    ///这儿的是带缓存的服务实现，使用了代理委托的设计模式
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“EmployeesService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeesService : cache.IEmployeesService
    {
        private IEmployeesService employeesServiceDelegate = new baseService.EmployeesService();

        public Employee Get(string id)
        {
            return employeesServiceDelegate.Get(id);
        }

        public void Create(Employee employee)
        {
            employeesServiceDelegate.Create(employee);
        }

        public void Update(Employee employee)
        {
            employeesServiceDelegate.Update(employee);
        }

        public void Delete(string id)
        {
            employeesServiceDelegate.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeesServiceDelegate.GetAll();
        }
    }
}
