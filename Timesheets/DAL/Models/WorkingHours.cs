using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public int IdContract { get; set; }
        public int IdEmpl { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsInvoiceExposed { get; set; }
        public bool WorkWasPaid { get; set; }
    }
}
