namespace Kernel.Services
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class _BaseService<TEntity> where TEntity : _BaseModel
    {
        protected UnitOfWork<TEntity> unitOfWork { get; set; }

        public _BaseService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork<TEntity>(context);
        }

        public DbContextTransaction GetTransaction()
        {
            return this.unitOfWork.BeginTransaction();
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return this.unitOfWork.repository.Get();
        }

        public void Create(TEntity model)
        {
            using (var transaction = this.GetTransaction())
            {
                this.unitOfWork.repository.Insert(model);
                this.unitOfWork.Commit();
            }
        }

        public void Update(TEntity model)
        {
            using (var transaction = this.GetTransaction())
            {
                this.unitOfWork.repository.Update(model);
                this.unitOfWork.Commit();
            }
        }


        public void Delete(TEntity model)
        {
            using (var transaction = this.GetTransaction())
            {
                this.unitOfWork.repository.Delete(model);
                this.unitOfWork.Commit();
            }
        }
    }
}
