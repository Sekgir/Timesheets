using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        TimesheetsContext _context;
        public TasksRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public Task GetById(long id)
        {
            return _context.Tasks.Find(id);
        }

        public bool Create(Task task)
        {
            try
            {
                _context.Add(task);
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
                Task task = _context.Tasks.Find(id);
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Task task)
        {
            try
            {
                Task task1 = _context.Tasks.Find(task.Id);
                if (task1 != null)
                {
                    task1.IdContract = task.IdContract;
                    task1.Name = task.Name;
                    task1.Amount = task.Amount;
                    task1.FixedAmount = task.FixedAmount;
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
