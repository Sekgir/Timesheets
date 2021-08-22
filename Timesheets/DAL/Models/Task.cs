using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public class Task : BaseEntity
    {
        public long IdContract { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool FixedAmount { get; set; }

        public Contract Contract { get; set; }
        public ICollection<InvoiceTask> InvoiceTasks { get; set; }
        public ICollection<TaskEmployee> TaskEmployees { get; set; }
    }
}
