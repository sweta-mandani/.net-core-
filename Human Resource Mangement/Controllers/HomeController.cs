using HRM.DATA;
using HRM.DATA.Interface;
using Human_Resource_Mangement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Human_Resource_Mangement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepo _EmployeeRepo;

        public HomeController(IEmployeeRepo EmployeeRepo)
        {
            this._EmployeeRepo = EmployeeRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> model = _EmployeeRepo.GetAllEmployee().Select(s => new Employee
            {
                EmployeeId = s.EmployeeId,
                Name = s.Name,
                Salary = s.Salary,
                IsManager = s.IsManager,
                Manager = s.Manager,
                Phone=s.Phone,
                Department=s.Department,
                Email = s.Email
            }) ;
            return View("Index", model);
        

    }

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
