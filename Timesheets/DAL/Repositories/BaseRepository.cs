using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> dbSet { get; set; }
        protected TimesheetsContext context { get; set; }

        public BaseRepository(TimesheetsContext context, DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
            this.context = context;
        }

        public TEntity GetById(long id)
        {
            return dbSet.Find(id);
        }

        public bool Create(TEntity entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
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
                TEntity entity = dbSet.Find(id);
                dbSet.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(TEntity entity)
        {
            try
            {
                dbSet.Update(entity);
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }
    }
}
