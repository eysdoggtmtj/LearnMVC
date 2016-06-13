namespace Kernel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.Entity;

    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        #region  Get

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        #endregion

        #region Insert

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region Delete

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            await DeleteAsync(entityToDelete);
        }

        public virtual void DeleteOn(Expression<Func<TEntity, bool>> filter)
        {
            dbSet.Where(filter).ToList().ForEach(entityToDelete =>
            {
                Delete(entityToDelete);
            });
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            this.context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region Update

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            this.context.SaveChanges();
        }


        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        #endregion

        public virtual long Count()
        {
            return dbSet.LongCount();
        }
    }

}
