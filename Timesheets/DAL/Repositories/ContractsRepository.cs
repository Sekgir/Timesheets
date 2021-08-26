using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class ContractsRepository : BaseRepository<Contract>, IContractsRepository
    {
        public ContractsRepository(TimesheetsContext context) : base(context, context.Contracts)
        {
            
        }
    }
}
