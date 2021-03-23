using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DATA.Interface
{
    public interface IEmployeeRepo
    {
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int EmployeeId);
        void DeleteEmployee(int EmployeeId);
        void UpdateEmployee(Employee employee);
    }
}
