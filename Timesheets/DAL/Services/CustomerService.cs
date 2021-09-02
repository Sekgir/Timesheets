using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Services
{
    public class CustomerService
    {
        TimesheetsContext _context;
        ICustomersRepository _repository;

        public CustomerService(TimesheetsContext context, ICustomersRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public Customer GetCustomerById(long id)
        {
            return _repository.GetById(id);
        }

        public IList<Contract> GetContractsByCustomer(long id)
        {
            var customer = _repository.GetById(id);
            _context.Entry(customer).Collection(c => c.Contracts).Load();
            return customer.Contracts.ToList();
        }

        //public ICollection<Contract> GetsByCustomer(long id)
        //{
        //    var customer = _repository.GetById(id);
        //    _context.Entry(customer).Reference(c => c.Contracts).Load();
        //    return customer.Contracts;
        //}
    }
}
