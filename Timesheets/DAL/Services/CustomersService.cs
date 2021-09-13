using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Services
{
    public class CustomersService : IDisposable
    {
        TimesheetsContext _context;
        ICustomersRepository _customersRepository;
        IContractsRepository _contractsRepository;
        IPersonsRepository _personsRepository;

        public CustomersService(TimesheetsContext context, ICustomersRepository customersRepository, IContractsRepository contractsRepository, IPersonsRepository personsRepository)
        {
            _context = context;
            _customersRepository = customersRepository;
            _contractsRepository = contractsRepository;
            _personsRepository = personsRepository;
        }

        public async Task<Customer> GetCustomerById(long id)
        {
            var result = await _customersRepository.GetById(id);
            await _customersRepository.LoadMember(result, item => item.Person);
            return result;
        }

        public async Task<ICollection<Contract>> GetContractsByCustomerId(long id)
        {
            Customer customer = await _customersRepository.GetById(id);
            await _customersRepository.LoadMemberCollection(customer, item => item.Contracts);
            return customer.Contracts;
        }
        public async System.Threading.Tasks.Task CreateContract(long id, int number)
        {
            Customer customer = await _customersRepository.GetById(id);
            Contract contract = new Contract() { Number = number, Customer = customer};
            await _contractsRepository.Create(contract);
            await Save();
        }
        public async Task<ICollection<Invoice>> GetInvoicesByCustomerId(long id)
        {
            Customer customer = await _customersRepository.GetById(id);
            await _customersRepository.LoadMemberCollection(customer, p => p.Contracts);
            List<Invoice> invoices = new List<Invoice>();
            foreach (var entity in customer.Contracts)
            {
                await _contractsRepository.LoadMemberCollection(entity, item => item.Invoices);
                invoices.AddRange(entity.Invoices);
            }
            return invoices;
        }
        public async System.Threading.Tasks.Task CreateCustomer(Person person)
        {
            await _personsRepository.Create(person);
            Customer customer = new Customer()  { Person = person };
            await _customersRepository.Create(customer);
            await Save();
        }

        public async System.Threading.Tasks.Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
