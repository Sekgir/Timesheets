using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(long id);
        bool Create(T person);
        bool Update(T person);
        bool Delete(long id);
    }
}
