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

        public void DeleteEmployee(long id)
        {
            Employee student = GetEmployee(id);
            EmployeeEntity.Remove(student);
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return EmployeeEntity.AsEnumerable();
        }

        public Employee GetEmployee(long id)
        {
            return EmployeeEntity.SingleOrDefault(s => s.EmployeeId == id);
        }

        public void SaveEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdateStudent(Employee employee)
        {
            context.SaveChanges();
        }
    }
}
