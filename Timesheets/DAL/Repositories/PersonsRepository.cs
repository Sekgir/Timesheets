using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class PersonsRepository : BaseRepository<Person>, IPersonsRepository
    {
        public PersonsRepository(TimesheetsContext context) : base(context, context.Persons)
        {

        }
        public Person GetByName(string name)
        {
            return context.Persons.Where(item => $"{item.LastName} {item.FirstName}".Contains(name, StringComparison.OrdinalIgnoreCase))?.First();
        }
        public ICollection<Person> GetList(int skip, int take)
        {
            return context.Persons.Skip(skip).Take(take).ToList();
        }
    }
}
