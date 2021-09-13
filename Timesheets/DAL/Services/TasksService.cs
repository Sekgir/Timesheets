using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Services
{
    public class TasksService : IDisposable
    {
        TimesheetsContext _context;
        ITasksRepository _taskRepository;

        public TasksService(TimesheetsContext context, ITasksRepository taskRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
        }

        public async Task CreateTask(DAL.Models.Task task)
        {
            await _taskRepository.Create(task);
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
