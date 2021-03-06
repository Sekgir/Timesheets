using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Interfaces
{
    public interface IPersonsRepository : IRepository<Person>
    {
        Person GetByName(string name);
        ICollection<Person> GetList(int skip, int take);
    }
}
