using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        TimesheetsContext _context;
        public CustomersRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public Customer GetById(long id)
        {
            return _context.Customers.Find(id);
        }

        public bool Create(Customer customer)
        {
            try
            {
                _context.Add(customer);
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
                Customer customer = _context.Customers.Find(id);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Customer customer)
        {
            try
            {
                Customer customer1 = _context.Customers.Find(customer.Id);
                if (customer1 != null)
                {
                    customer1.IdPerson = customer.IdPerson;
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
