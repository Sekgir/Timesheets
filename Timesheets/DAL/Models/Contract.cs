using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Contract : BaseEntity
    {
        public long IdCustomer { get; set; }
        public int Number { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
