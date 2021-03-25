using HRM.DATA;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.IManager
{
    public interface IEmployeeManager
    {
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(long id);
        void DeleteEmployee(long id);
        void UpdateEmployee(Employee employee);
    }
}
