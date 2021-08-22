using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Employee : BaseEntity
    {
        public long IdPerson { get; set; }
        public double Rate { get; set; }

        public Person Person { get; set; }
        public ICollection<TaskEmployee> TaskEmployees { get; set; }
    }
}
