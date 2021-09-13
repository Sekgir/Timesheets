using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Repositories;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Services
{
    public class ContractsService : IDisposable
    {
        TimesheetsContext _context;
        IContractsRepository _contractsRepository;
        ITasksRepository _tasksRepository;
        ITaskEmployeesRepository _taskEmployeesRepository;
        IInvoicesRepository _invoicesRepository;
        IInvoiceTasksRepository _invoiceTasksRepository;
        IInvoiceTaskEmplsRepository _invoiceTaskEmplsRepository;

        public ContractsService(TimesheetsContext context, IContractsRepository contractsRepository,
            ITasksRepository tasksRepository, ITaskEmployeesRepository taskEmployeesRepository, IInvoicesRepository invoicesRepository,
            IInvoiceTasksRepository invoiceTasksRepository, IInvoiceTaskEmplsRepository invoiceTaskEmplsRepository)
        {
            _context = context;
            _contractsRepository = contractsRepository;
            _tasksRepository = tasksRepository;
            _taskEmployeesRepository = taskEmployeesRepository;
            _invoicesRepository = invoicesRepository;
            _invoiceTasksRepository = invoiceTasksRepository;
            _invoiceTaskEmplsRepository = invoiceTaskEmplsRepository;
        }

        public async Task<Contract> GetContractById(int idContract)
        {
            var contract = await _contractsRepository.GetById(idContract);
            return contract;
        }

        public async Task<ICollection<Invoice>> GetInvoices(int idContract)
        {
            var contract = await _contractsRepository.GetById(idContract);
            await _contractsRepository.LoadMemberCollection(contract, item => item.Invoices);
            return contract.Invoices;
        }

        public async Task<Invoice> CreateInvoice(int idContract)
        {
            Invoice invoice = null;
            var contract = await _contractsRepository.GetById(idContract);
            await _contractsRepository.LoadMemberCollection(contract, item => item.Tasks);
            foreach (var task in contract.Tasks.Where(item => !item.FixedAmount))
            {
                await _tasksRepository.LoadMemberCollection(task, item => item.TaskEmployees);
                foreach (var taskEmployee in task.TaskEmployees)
                {
                    await _taskEmployeesRepository.LoadMember(taskEmployee, item => item.InvoiceTaskEmpl);

                    if (taskEmployee.InvoiceTaskEmpl != null)
                    {
                        continue;
                    }

                    if (invoice == null)
                    {
                        invoice = await NewInvoice(contract);
                    }

                    await _taskEmployeesRepository.LoadMember(taskEmployee, item => item.Employee);
                    invoice.Amount += taskEmployee.Time.TotalHours * taskEmployee.Employee.Rate;
                    var invoiceTaskEmpl = new InvoiceTaskEmpl()
                    {
                        Invoice = invoice,
                        TaskEmployee = taskEmployee
                    };
                    await _invoiceTaskEmplsRepository.Create(invoiceTaskEmpl);
                    await _invoicesRepository.Update(invoice);
                }
            }
            foreach (var task in contract.Tasks.Where(item => item.FixedAmount))
            {
                await _tasksRepository.LoadMember(task, item => item.InvoiceTask);
                if (task.InvoiceTask != null)
                {
                    continue;
                }

                if (invoice == null)
                {
                    invoice = await NewInvoice(contract);
                }

                invoice.Amount += task.Amount;
                var invoiceTask = new InvoiceTask()
                {
                    Task = task,
                    Invoice = invoice
                };
                await _invoiceTasksRepository.Create(invoiceTask);
                await _invoicesRepository.Update(invoice);
            }
            await Save();
            return invoice;
        }

        private async Task<Invoice> NewInvoice(Contract contract)
        {
            Invoice invoice = new Invoice() { Contract = contract };
            await _invoicesRepository.Create(invoice);
            return invoice;
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
