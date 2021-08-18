using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class InvoiceTask : BaseEntity
    {
        public long IdInvoice { get; set; }
        public long IdTask { get; set; }
    }
}
