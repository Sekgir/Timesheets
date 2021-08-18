using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public double Salary { get; set; } //Почасовая оплата
    }
}
