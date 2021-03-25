using HRM.DATA;
using HRM.DATA.Interface;
using Human_Resource_Mangement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Human_Resource_Mangement.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IEmployeeRepo _EmployeeRepo;

        public HomeController(IEmployeeRepo EmployeeRepo, ILogger<HomeController> logger)
        {
            this._EmployeeRepo = EmployeeRepo;
            _logger = logger;
        }
      
        // Home Page
        
        [ServiceFilter(typeof(CustomActionFilter))]
       
        public IActionResult Display()
        {
            return View();


        }
      //Employee List
        [ResponseCache(Duration = 5)]
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
            _logger.LogInformation("The EmployeeList access");
            return View("Index", model);
        

    }
        [HttpGet("{EmployeeId}")]
        public IActionResult DetailEmployee(int EmployeeId)
        {
            Employee model = _EmployeeRepo.GetEmployee(EmployeeId);
            _logger.LogInformation("The Deatail of employee access");
            return View(model);


        }

        //Add Employee
        [HttpGet]
        public IActionResult AddEmployee(int? EmployeeId)
        {
            Employee model = new Employee();
          
            if (EmployeeId.HasValue)
            {
                Employee emp = _EmployeeRepo.GetEmployee(EmployeeId.Value); 
                if (emp != null)
                {
                    model.EmployeeId = emp.EmployeeId;
                    model.Name = emp.Name;
                    model.Salary = emp.Salary;
                    model.IsManager = emp.IsManager;
                    model.Manager = emp.Manager;
                    model.Phone = emp.Phone;
                  
                    model.Department = emp.Department;
                    model.Email = emp.Email;
                }
            }
            return PartialView("~/Views/Home/AddEmployee.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEmployee(int? EmployeeId, Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !EmployeeId.HasValue;
                    Employee emp = isNew ? new Employee
                    {
                      
                    } : _EmployeeRepo.GetEmployee(EmployeeId.Value);
                     emp.EmployeeId = model.EmployeeId;
                     emp.Name=model.Name;
                     emp.Salary=model.Salary;
                     emp.IsManager=model.IsManager;
                     emp.Manager=model.Manager;
                     emp.Phone=model.Phone;
                     emp.Department=model.Department;
                     emp.Email=model.Email;
                
                if (isNew)
                    {
                    _EmployeeRepo.SaveEmployee(emp);
                    }
                    else
                    {
                    _EmployeeRepo.UpdateEmployee(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            _logger.LogInformation(" Add Employee Succeefully");
            return RedirectToAction("Index");
        }

        //Edit Employee
        [HttpGet]
        public IActionResult EditEmployee(int? EmployeeId)
        {
            Employee model = new Employee();
            if (EmployeeId.HasValue)
            {
                Employee emp = _EmployeeRepo.GetEmployee(EmployeeId.Value);
                if (emp != null)
                {
                    model.EmployeeId = emp.EmployeeId;
                    model.Name = emp.Name;
                    model.Salary = emp.Salary;
                    model.IsManager = emp.IsManager;
                    model.Manager = emp.Manager;
                    model.Phone = emp.Phone;
                    model.Department = emp.Department;
                    model.Email = emp.Email;
                }
            }
            return PartialView("~/Views/Home/EditEmployee.cshtml", model);
        }
        [HttpPost]
        public ActionResult EditEmployee(int? EmployeeId, Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !EmployeeId.HasValue;
                    Employee emp = isNew ? new Employee
                    {

                    } : _EmployeeRepo.GetEmployee(EmployeeId.Value);
                    emp.EmployeeId = model.EmployeeId;
                    emp.Name = model.Name;
                    emp.Salary = model.Salary;
                    emp.IsManager = model.IsManager;
                    emp.Manager = model.Manager;
                    emp.Phone = model.Phone;
                    emp.Department = model.Department;
                    emp.Email = model.Email;

                    if (isNew)
                    {
                        _EmployeeRepo.SaveEmployee(emp);
                    }
                    else
                    {
                        _EmployeeRepo.UpdateEmployee(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            _logger.LogInformation(" update employee successfully");
            return RedirectToAction("Index");
        }
        //DeleteEmployee
        [HttpGet]
        public IActionResult DeleteEmployee(int EmployeeId )
        {
           Employee emp = _EmployeeRepo.GetEmployee(EmployeeId);

            return View(emp);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int EmployeeId, IFormCollection form)
        {
            _EmployeeRepo.DeleteEmployee(EmployeeId);
            _logger.LogInformation(" Delete Employee");
            return RedirectToAction("Index");
        }
    }
}
