using HRM.BAL.IManager;
using HRM.DATA;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.ManagerRepo
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeManager _EmployeeRepo;
        public EmployeeManager(IEmployeeManager EmployeeRepo)
        {
            _EmployeeRepo = EmployeeRepo;
        }
        public void DeleteEmployee(long id)
        {
             _EmployeeRepo.DeleteEmployee(id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _EmployeeRepo.GetAllEmployee();
        }

        public Employee GetEmployee(long id)
        {
            return _EmployeeRepo.GetEmployee(id);
        }

        public void SaveEmployee(Employee employee)
        {
             _EmployeeRepo.SaveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _EmployeeRepo.UpdateEmployee(employee);

        }
    }
}
