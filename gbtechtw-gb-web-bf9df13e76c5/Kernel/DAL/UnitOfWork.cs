namespace Kernel.DAL
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitOfWork<TEntity> where TEntity : _BaseModel
    {
        private ApplicationDbContext context;
        private GenericRepository<TEntity> _repository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public GenericRepository<TEntity> repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new GenericRepository<TEntity>(context);
                }
                return _repository;
            }
        }

        public void Commit()
        {
            try
            {
                context.SaveChanges();
                this.BeginTransaction().Commit();
            }
            catch (SqlException)
            {
                this.BeginTransaction().Rollback();
            }
        }

        public DbContextTransaction BeginTransaction()
        {
            return this.context.BeginTransaction();
        }
    }
}
