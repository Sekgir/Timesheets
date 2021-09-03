using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public class InvoiceTaskEmpl : BaseEntity
    {
        public long IdInvoice { get; set; }
        public long IdTaskEmployee { get; set; }

        public Invoice Invoice { get; set; }
        public TaskEmployee TaskEmployee { get; set; }
    }
}
