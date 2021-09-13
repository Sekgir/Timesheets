using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Services
{
    public class EmployeesService : IDisposable
    {
        TimesheetsContext _context;
        IEmployeesRepository _employeesRepository;
        ITasksRepository _tasksRepository;
        ITaskEmployeesRepository _taskEmployeesRepository;
        
        public EmployeesService(TimesheetsContext context, IEmployeesRepository employeesRepository, ITasksRepository tasksRepository, ITaskEmployeesRepository taskEmployeesRepository)
        {
            _context = context;
            _employeesRepository = employeesRepository;
            _tasksRepository = tasksRepository;
            _taskEmployeesRepository = taskEmployeesRepository;
        }

        public async System.Threading.Tasks.Task AddTime(long employeeId, long taskId, double seconds)
        {
            var task = await _tasksRepository.GetById(taskId);
            var employee = await _employeesRepository.GetById(employeeId);
            var taskEmployee = new TaskEmployee() { Task = task, Employee = employee, Time = TimeSpan.FromSeconds(seconds) };
            await _taskEmployeesRepository.Create(taskEmployee);
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
