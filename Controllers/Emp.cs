
using Microsoft.AspNetCore.Mvc;
using TaskProj.Data;

namespace TaskProj.Controllers
{
    public class Emp : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Emp(IEmployeeRepository employeeRepository) { 
            _employeeRepository = employeeRepository;
        }

        public IActionResult Result()
        {
            var employees = _employeeRepository.GetEmployees();
            return View(employees);
        }
    }
}

