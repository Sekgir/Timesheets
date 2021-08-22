using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class TaskEmployee : BaseEntity
    {
        public long IdTask { get; set; }
        public long IdEmployee { get; set; }
        public TimeSpan Time { get; set; }
    }
}
