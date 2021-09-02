using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class InvoicesRepository : BaseRepository<Invoice>, IInvoicesRepository
    {
        public InvoicesRepository(TimesheetsContext context) : base(context, context.Invoices)
        {

        }
    }
}
