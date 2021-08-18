using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Contract : BaseEntity
    {
        public int IdCustomer { get; set; }
        public int Number { get; set; }
    }
}
