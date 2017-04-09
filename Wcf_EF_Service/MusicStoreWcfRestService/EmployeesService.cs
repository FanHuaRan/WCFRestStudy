using MusicStoreWcfRestContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MusicStoreWcfRestService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“EmployeesService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeesService : IEmployeesService
    {
        private static IList<Employee> employees = new List<Employee>
        {
            new Employee{ Id = "001", Name="张三", Department="开发部", Grade = "G7"},    
            new Employee{ Id = "002", Name="李四", Department="人事部", Grade = "G6"}
        };
        public Employee Get(string id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (null == employee)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode =HttpStatusCode.NotFound;
            }
            return employee;
        }

        public void Create(Employee employee)
        {
            employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            this.Delete(employee.Id);
            employees.Add(employee);
        }

        public void Delete(string id)
        {
            Employee employee = this.Get(id);
            if (null != employee)
            {
                employees.Remove(employee);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }
    }
}
