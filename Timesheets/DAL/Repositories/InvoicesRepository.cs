using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        TimesheetsContext _context;
        public InvoicesRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public Invoice GetById(long id)
        {
            return _context.Invoices.Find(id);
        }

        public bool Create(Invoice invoice)
        {
            try
            {
                _context.Add(invoice);
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
                Invoice invoice = _context.Invoices.Find(id);
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Invoice invoice)
        {
            try
            {
                Invoice invoice1 = _context.Invoices.Find(invoice.Id);
                if (invoice1 != null)
                {
                    invoice1.IdContract = invoice.IdContract;
                    invoice1.Amount = invoice.Amount;
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
