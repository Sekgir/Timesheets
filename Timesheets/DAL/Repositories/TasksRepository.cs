using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class TasksRepository : BaseRepository<Task>, ITasksRepository
    {
        public TasksRepository(TimesheetsContext context) : base(context, context.Tasks)
        {

        }
    }
}
