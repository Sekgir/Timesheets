using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;

namespace Timesheets.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> dbSet { get; set; }
        protected TimesheetsContext context { get; set; }

        public BaseRepository(TimesheetsContext context, DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
            this.context = context;
        }

        public async Task<TEntity> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Create(TEntity entity)
        {
            try
            {
                await context.AddAsync(entity);
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                TEntity entity = await dbSet.FindAsync(id);
                dbSet.Remove(entity);
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                dbSet.Update(entity);
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public async Task LoadMember<TProperty>(TEntity item, Expression<Func<TEntity, TProperty>> propertyExpression) where TProperty : class
        {
            await context.Entry(item).Reference(propertyExpression).LoadAsync();
        }

        public async Task LoadMemberCollection<TProperty>(TEntity item, Expression<Func<TEntity, IEnumerable<TProperty> >> propertyExpression) where TProperty : class
        {
            await context.Entry(item).Collection(propertyExpression).LoadAsync();
        }
    }
}
