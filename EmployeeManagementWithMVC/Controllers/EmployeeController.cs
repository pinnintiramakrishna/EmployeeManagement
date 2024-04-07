using EmployeeManagementWithMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;   
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.NextEmployeeId = _employeeRepository.GetAllEmployees().Max(id => id.EmployeeId) + 1;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employeeRepository.Create(employee);
                ViewBag.NextEmployeeId = _employeeRepository.GetAllEmployees().Max(id => id.EmployeeId) + 1;
                return View();
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Update
        public ActionResult Update(int empid)
        {
            Employee employee = _employeeRepository.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == empid);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee employee)
        {
            try
            {
                _employeeRepository.Update(employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int empid)
        {
            try
            {
                _employeeRepository.Delete(empid);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
