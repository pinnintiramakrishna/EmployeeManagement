using EmployeeService.Models;

namespace EmployeeService.Repository
{
    public class MockEmployeeRepository : IRepository
    {
        private List<Employee> Employees = new List<Employee>();
        public MockEmployeeRepository()
        {
            Employees.Add(new Employee() { EmployeeId = 1, FirstName = "EMP1FN", LastName = "EMP1LM", Designation = "EMP1DESG" });
            Employees.Add(new Employee() { EmployeeId = 2, FirstName = "EMP2FN", LastName = "EMP2LM", Designation = "EMP2DESG" });
            Employees.Add(new Employee() { EmployeeId = 3, FirstName = "EMP3FN", LastName = "EMP3LM", Designation = "EMP3DESG" });
        }
        public Employee Create(Employee employee)
        {
            employee.EmployeeId = Employees.Count + 1;
            Employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            Employee? emp = Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Designation = employee.Designation;

            return emp;
        }

        public Employee Delete(int employeeId)
        {
            Employee? emp = Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (emp != null)
            {
                Employees.Remove(emp);
            }
            return emp;
        }

        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        public Employee GetEmployee(int employeeId)
        {
            return Employees.FirstOrDefault(id => id.EmployeeId == employeeId);
        }
    }
}
