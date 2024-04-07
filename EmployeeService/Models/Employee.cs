using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace EmployeeService.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Designation { get; set; }
    }
}
