
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.DATA
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
       
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
public enum Department
{
    IT,
    Civil,
    Computer,
    AutoMobile
}
public enum Manager
{
    IT,
    Network,
    HR,
    AutoMobile
}
