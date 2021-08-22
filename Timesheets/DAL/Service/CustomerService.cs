using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Service
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

        public ICollection<Contract> GetContractsByCustomer(long id)
        {
            var customer = _repository.GetById(id);
            return customer.Contracts;
        }
    }
}
