using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Interfaces
{
    public interface IPersonsRepository
    {

        Person GetPersonById(int id);
        Person GetPersonByName(string name);
        IList<Person> GetPersonsList(int skip, int take);
        void Create(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}
