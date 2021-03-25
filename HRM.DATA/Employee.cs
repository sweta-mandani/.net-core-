
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

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "salary is required")]
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, MinimumLength = 10)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }


        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email is required")]
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
