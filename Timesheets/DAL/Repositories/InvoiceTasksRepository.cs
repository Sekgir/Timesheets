using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class InvoiceTasksRepository : IInvoiceTasksRepository
    {
        TimesheetsContext _context;
        public InvoiceTasksRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public InvoiceTask GetById(long id)
        {
            return _context.InvoiceTask.Find(id);
        }

        public bool Create(InvoiceTask invoiceTask)
        {
            try
            {
                _context.Add(invoiceTask);
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
                InvoiceTask invoiceTask = _context.InvoiceTask.Find(id);
                _context.InvoiceTask.Remove(invoiceTask);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(InvoiceTask invoiceTask)
        {
            try
            {
                InvoiceTask invoiceTask1 = _context.InvoiceTask.Find(invoiceTask.Id);
                if (invoiceTask1 != null)
                {
                    invoiceTask1.IdInvoice = invoiceTask.IdInvoice;
                    invoiceTask1.IdTask = invoiceTask.IdTask;
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
