using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Requests
{
    public class WorkingHoursAddOpeningHours
    {
        public int IdContract { get; set; }
        public int IdEmpl { get; set; }
        public double Time { get; set; }
    }
}
