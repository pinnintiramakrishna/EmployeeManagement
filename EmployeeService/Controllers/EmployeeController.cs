using EmployeeService.Models;
using EmployeeService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepository _repository;
        //private IRepository _repository1;
        public EmployeeController(IRepository repository) {
            _repository = repository;
           // _repository1 = repository1;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return (_repository.GetAllEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _repository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();// (new EmployeeResponse() { Message = "No Employee found." });
            }
            else
            {
                return Ok((new EmployeeResponse() { Employee = employee, Message = "Found Employee details.", StatusCode = StatusCodes.Status200OK }));
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public List<Employee> Post(Employee employee)
        {
            Employee emp= _repository.Create(employee);

            return _repository.GetAllEmployees();
            //return (new EmployeeResponse() { Employee = emp, Message = "New Employee Created Successfully." });
        }

        // PUT api/<EmployeeController>
        [HttpPut]
        public EmployeeResponse Put(Employee employee)
        {
            Employee emp = _repository.Update(employee);

            return (new EmployeeResponse() { Employee = emp, Message = " Employee details Updated Successfully." });
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public EmployeeResponse Delete(int id)
        {
            Employee emp = _repository.Delete(id);

            return (new EmployeeResponse() { Employee = emp, Message = " Employee details Deleted Successfully." });
        }
    }
}
