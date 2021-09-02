using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class InvoiceTasksRepository : BaseRepository<InvoiceTask>, IInvoiceTasksRepository
    {
        public InvoiceTasksRepository(TimesheetsContext context) : base(context, context.InvoiceTask)
        {

        }
    }
}
