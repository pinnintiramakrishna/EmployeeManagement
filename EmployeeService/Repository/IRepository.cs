using EmployeeService.Models;

namespace EmployeeService.Repository
{
    public interface IRepository
    {
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int employeeId);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int employeeId);
    }
}
