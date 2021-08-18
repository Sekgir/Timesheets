using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
    }
}
