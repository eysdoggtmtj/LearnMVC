namespace Kernel.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        private DbContextTransaction transaction { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Keyword> Keywords { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<ArticleCategoryMapping> ArticleCategoryMapping { get; set; }

        public ApplicationDbContext()
           : base("name=BlogDbContext", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbContextTransaction BeginTransaction()
        {
            if (this.transaction == null)
            {
                this.transaction = this.Database.BeginTransaction();
            }

            return this.transaction;
        }
    }
}
