using System;

namespace Timesheets.DAL.Models
{
    public class InvoiceTask : BaseEntity
    {
        public long IdInvoice { get; set; }
        public long IdTask { get; set; }

        public Invoice Invoice { get; set; }
        public Task Task { get; set; }
    }
}
