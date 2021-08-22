using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class ContractsRepository : IContractsRepository
    {
        TimesheetsContext _context;
        public ContractsRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public Contract GetById(long id)
        {
            return _context.Contracts.Find(id);
        }

        public bool Create(Contract contract)
        {
            try
            {
                _context.Add(contract);
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
                Contract contract = _context.Contracts.Find(id);
                _context.Contracts.Remove(contract);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Contract contract)
        {
            try
            {
                Contract contract1 = _context.Contracts.Find(contract.Id);
                if (contract1 != null)
                {
                    contract1.IdCustomer = contract.IdCustomer;
                    contract1.Number = contract.Number;
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
