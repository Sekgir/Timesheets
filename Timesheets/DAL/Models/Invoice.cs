using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int IdContract { get; set; }
        public double Amount { get; set; }
    }
}
