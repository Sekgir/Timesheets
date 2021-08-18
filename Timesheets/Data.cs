using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets
{
    public class Data
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
