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
    /// <summary>
    /// 带输出缓存的雇员服务实现
    /// 2017/04/22 fhr
    /// </summary>
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
