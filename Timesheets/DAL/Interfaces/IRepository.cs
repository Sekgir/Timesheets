using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Timesheets.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(long id);
        Task<bool> Create(TEntity person);
        Task<bool> Update(TEntity person);
        Task<bool> Delete(long id);
        Task LoadMember<TProperty>(TEntity item, Expression<Func<TEntity, TProperty>> propertyExpression) where TProperty : class;
        Task LoadMemberCollection<TProperty>(TEntity item, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TProperty : class;
    }
}
