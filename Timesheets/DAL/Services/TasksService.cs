using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Services
{
    public class TasksService
    {
        ITasksRepository _taskRepository;

        public TasksService(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CreateTask(DAL.Models.Task task)
        {
            await _taskRepository.Create(task);
        }
    }
}
