using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DATA.Interface
{
    public interface IEmployeeRepo
    {
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(long id);
        void DeleteEmployee(long id);
        void UpdateStudent(Employee employee);
    }
}
