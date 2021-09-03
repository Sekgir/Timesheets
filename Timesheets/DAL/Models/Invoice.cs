using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Invoice : BaseEntity
    {
        public long IdContract { get; set; }
        public double Amount { get; set; }

        public Contract Contract { get; set; }
        public ICollection<InvoiceTaskEmpl> InvoiceTaskEmpls { get; set; }
        public ICollection<InvoiceTask> InvoiceTasks { get; set; }
    }
}
