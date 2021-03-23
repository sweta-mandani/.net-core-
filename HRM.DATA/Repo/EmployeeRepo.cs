using HRM.DATA.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DATA.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private ApplicationDBContext context;
        private DbSet<Employee> EmployeeEntity;

        public EmployeeRepo(ApplicationDBContext context)
        {
            this.context = context;
            EmployeeEntity = context.Set<Employee>();
        }

        public void DeleteEmployee(int EmployeeId )
        {
            Employee emp = GetEmployee(EmployeeId);
            EmployeeEntity.Remove(emp);
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return EmployeeEntity.AsEnumerable();
        }

        public Employee GetEmployee(int EmployeeId)
        {
            return EmployeeEntity.SingleOrDefault(s => s.EmployeeId == EmployeeId);
        }

        public void SaveEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            context.SaveChanges();
        }
    }
}
