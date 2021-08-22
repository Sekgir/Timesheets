using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class TaskEmployeesRepository : ITaskEmployeesRepository
    {
        TimesheetsContext _context;
        public TaskEmployeesRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public TaskEmployee GetById(long id)
        {
            return _context.TaskEmployee.Find(id);
        }

        public bool Create(TaskEmployee taskEmployee)
        {
            try
            {
                _context.Add(taskEmployee);
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
                TaskEmployee taskEmployee = _context.TaskEmployee.Find(id);
                _context.TaskEmployee.Remove(taskEmployee);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(TaskEmployee taskEmployee)
        {
            try
            {
                TaskEmployee taskEmployee1 = _context.TaskEmployee.Find(taskEmployee.Id);
                if (taskEmployee1 != null)
                {
                    taskEmployee1.IdEmployee = taskEmployee.IdEmployee;
                    taskEmployee1.IdTask = taskEmployee.IdTask;
                    taskEmployee1.Time = taskEmployee.Time;
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
