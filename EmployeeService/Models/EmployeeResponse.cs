namespace EmployeeService.Models
{
    public class EmployeeResponse
    {
        public Employee Employee { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
    }
}
