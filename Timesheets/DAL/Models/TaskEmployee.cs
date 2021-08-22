using System;

namespace Timesheets.DAL.Models
{
    public class TaskEmployee : BaseEntity
    {
        public long IdTask { get; set; }
        public long IdEmployee { get; set; }
        public TimeSpan Time { get; set; }

        public Task Task { get; set; }
        public Employee Employee { get; set; }
    }
}
