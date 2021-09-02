using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets
{
    public class Data
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        //public List<WorkingHours> WorkingHours { get; set; } = new List<WorkingHours>();
        public List<Person> Persons { get; set; } = TemporaryValues.GetPeopleList();
    }
}
