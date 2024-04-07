namespace EmployeeManagementWithMVC.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> Employees = new List<Employee>();
        private int EmployeeId = 100;
        public EmployeeRepository() {

            Create(new Employee() { FirstName = "EMP1FN", LastName = "EMP1LM", Designation = "EMP1DESG" });
            Create(new Employee() { FirstName = "EMP2FN", LastName = "EMP2LM", Designation = "EMP2DESG" });
            Create(new Employee() { FirstName = "EMP3FN", LastName = "EMP3LM", Designation = "EMP3DESG" });
            

        }
        public Employee Create(Employee employee)
        {
            employee.EmployeeId = EmployeeId + Employees.Count;
            Employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            Employee? emp = Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);

            emp.FirstName= employee.FirstName;  
            emp.LastName= employee.LastName;
            emp.Designation= employee.Designation;

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
    }
}
