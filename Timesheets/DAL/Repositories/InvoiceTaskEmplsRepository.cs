using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class InvoiceTaskEmplsRepository : BaseRepository<InvoiceTaskEmpl>, IInvoiceTaskEmplsRepository
    {
        public InvoiceTaskEmplsRepository(TimesheetsContext context) : base(context, context.InvoiceTaskEmpl)
        {

        }
    }
}
