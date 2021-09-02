using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class TaskEmployeesRepository : BaseRepository<TaskEmployee>, ITaskEmployeesRepository
    {
        public TaskEmployeesRepository(TimesheetsContext context) : base(context, context.TaskEmployee)
        {

        }
    }
}
