using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Services
{
    public class CustomersService
    {
        ICustomersRepository _customersRepository;
        IContractsRepository _contractsRepository;
        IInvoicesRepository _invoicesRepository;
        IPersonsRepository _personsRepository;

        public CustomersService(ICustomersRepository customersRepository, IContractsRepository contractsRepository, IInvoicesRepository invoicesRepository, IPersonsRepository personsRepository)
        {
            _customersRepository = customersRepository;
            _contractsRepository = contractsRepository;
            _invoicesRepository = invoicesRepository;
            _personsRepository = personsRepository;
        }

        public async Task<Customer> GetCustomerById(long id)
        {
            return await _customersRepository.GetById(id);
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
        }
    }
}
