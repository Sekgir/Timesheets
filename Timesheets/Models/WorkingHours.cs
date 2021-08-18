using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class WorkingHours
    {
        public int IdEmpl { get; set; }
        public TimeSpan Time { get; set; }
    }
}
