using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DATA
{
    public class Employee 
    {

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string IsManager { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
