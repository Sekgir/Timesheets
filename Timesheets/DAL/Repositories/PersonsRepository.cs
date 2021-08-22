using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        TimesheetsContext _context;
        public PersonsRepository(TimesheetsContext context)
        {
            _context = context;
        }

        public Person GetById(long id)
        {
            return _context.Persons.Find(id);
        }
        public Person GetByName(string name)
        {
            return _context.Persons.Where(item => $"{item.LastName} {item.FirstName}".Contains(name, StringComparison.OrdinalIgnoreCase))?.First();
        }
        public ICollection<Person> GetList(int skip, int take)
        {
            return _context.Persons.Skip(skip).Take(take).ToList();
        }

        public bool Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(long id)
        {
            try
            {
                Person person = _context.Persons.Find(id);
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Person person)
        {
            try
            {
                Person person1 = _context.Persons.Find(person.Id);
                if (person1 != null)
                {
                    person1.LastName = person.LastName;
                    person1.FirstName = person.FirstName;
                    person1.Email = person.Email;
                    person1.Company = person.Company;
                    person1.Age = person.Age;
                }
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }
    }
}
