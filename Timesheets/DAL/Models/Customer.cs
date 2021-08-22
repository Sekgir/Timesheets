using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Customer : BaseEntity
    {
        public long IdPerson { get; set; }

        public Person Person { get; set; }
        public ICollection<Contract> Contracts { get; set; } 
    }
}
