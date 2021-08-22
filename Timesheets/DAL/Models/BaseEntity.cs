using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
    }
}
