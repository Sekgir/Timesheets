using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        TimesheetsContext _context;
        public EmployeesRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public Employee GetById(long id)
        {
            return _context.Employees.Find(id);
        }

        public bool Create(Employee employee)
        {
            try
            {
                _context.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(long id)
        {
            try
            {
                Employee employee = _context.Employees.Find(id);
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Employee employee)
        {
            try
            {
                Employee employee1 = _context.Employees.Find(employee.Id);
                if (employee1 != null)
                {
                    employee1.IdPerson = employee.IdPerson;
                    employee1.Rate = employee.Rate;
                }
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }
    }
}
