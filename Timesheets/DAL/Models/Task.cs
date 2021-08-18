using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Task : BaseEntity
    {
        public long IdContract { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool FixedAmount { get; set; }
    }
}
