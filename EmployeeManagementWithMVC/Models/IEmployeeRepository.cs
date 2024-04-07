using System.Runtime.InteropServices;

namespace EmployeeManagementWithMVC.Models
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int employeeId);
        List<Employee> GetAllEmployees();
    }
}
