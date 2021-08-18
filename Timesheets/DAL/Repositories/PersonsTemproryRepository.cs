using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Repositories
{
    public class PersonsTemproryRepository : IPersonsRepository
    {
        Data _data;
        public PersonsTemproryRepository(Data data)
        {
            _data = data;
        }

        public Person GetPersonById(int id)
        {
            return _data.Persons.Find(item => item.Id == id);
        }
        public Person GetPersonByName(string name)
        {
            return _data.Persons.Find(item => $"{item.LastName} {item.FirstName}".Contains(name, StringComparison.OrdinalIgnoreCase));
        }
        public IList<Person> GetPersonsList(int skip, int take)
        {
            return _data.Persons.Skip(skip).Take(take).ToList();
        }

        public void Create(Person person)
        {
            if (_data.Persons.Count == 0)
            {
                person.Id = 0;
            }
            else
            {
                person.Id = _data.Persons.Max(item => item.Id) + 1;
            }
            _data.Persons.Add(person);
        }

        public void Delete(int id)
        {
            Person person = _data.Persons.Find(item => item.Id == id);
            _data.Persons.Remove(person);
        }

        public void Update(Person person)
        {
            Person person1 = _data.Persons.Find(item => item.Id == person.Id);
            if (person1 != null)
            {
                person1.LastName = person.LastName;
                person1.FirstName = person.FirstName;
                person1.Email = person.Email;
                person1.Company = person.Company;
                person1.Age = person.Age;
            }
        }
    }
}
