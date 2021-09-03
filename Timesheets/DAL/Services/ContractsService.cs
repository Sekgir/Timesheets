﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Services
{
    public class ContractsService
    {
        IContractsRepository _contractsRepository;
        ITasksRepository _tasksRepository;
        ITaskEmployeesRepository _taskEmployeesRepository;
        IInvoicesRepository _invoicesRepository;
        IInvoiceTasksRepository _invoiceTasksRepository;
        IInvoiceTaskEmplsRepository _invoiceTaskEmplsRepository;


        public ContractsService(IContractsRepository contractsRepository, ITasksRepository tasksRepository,
            ITaskEmployeesRepository taskEmployeesRepository, IInvoicesRepository invoicesRepository,
            IInvoiceTasksRepository invoiceTasksRepository, IInvoiceTaskEmplsRepository invoiceTaskEmplsRepository)
        {
            _contractsRepository = contractsRepository;
            _tasksRepository = tasksRepository;
            _taskEmployeesRepository = taskEmployeesRepository;
            _invoicesRepository = invoicesRepository;
            _invoiceTasksRepository = invoiceTasksRepository;
            _invoiceTaskEmplsRepository = invoiceTaskEmplsRepository;
        }

        public async Task<Contract> GetContractById(int iidContract)
        {
            var contract = await _contractsRepository.GetById(iidContract);
            return contract;
        }

        public async Task<ICollection<Invoice>> GetInvoices(int idContract)
        {
            var contract = await _contractsRepository.GetById(idContract);
            await _contractsRepository.LoadMemberCollection(contract, item => item.Invoices);
            return contract.Invoices;
        }

        public async System.Threading.Tasks.Task CreateInvoice(int idContract)
        {
            Invoice invoice = null;
            var contract = await _contractsRepository.GetById(idContract);
            await _contractsRepository.LoadMemberCollection(contract, item => item.Tasks);
            foreach (var task in contract.Tasks.Where(item => !item.FixedAmount))
            {
                await _tasksRepository.LoadMemberCollection(task, item => item.TaskEmployees);
                foreach (var taskEmployee in task.TaskEmployees)
                {
                    if (invoice == null)
                    {
                        invoice = await NewInvoice();
                    }

                    await _taskEmployeesRepository.LoadMember(taskEmployee, item => item.Employee);
                    invoice.Amount += taskEmployee.Time.TotalHours * taskEmployee.Employee.Rate;
                    var invoiceTaskEmpl = new InvoiceTaskEmpl()
                    {
                        Invoice = invoice,
                        TaskEmployee = taskEmployee
                    };
                    await _invoiceTaskEmplsRepository.Create(invoiceTaskEmpl);
                }
            }
            foreach (var task in contract.Tasks.Where(item => item.FixedAmount))
            {
                if (invoice == null)
                {
                    invoice = await NewInvoice();
                }

                invoice.Amount += task.Amount;
                var invoiceTask = new InvoiceTask()
                {
                    Task = task,
                    Invoice = invoice
                };
                await _invoiceTasksRepository.Create(invoiceTask);
            }
            await _invoicesRepository.Update(invoice);
        }

        private async Task<Invoice> NewInvoice()
        {
            Invoice invoice = new Invoice();
            await _invoicesRepository.Create(invoice);
            return invoice;
        }
    }
}
