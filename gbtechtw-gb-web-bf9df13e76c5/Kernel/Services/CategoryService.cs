using Kernel.DAL;
using Kernel.Models;
using Kernel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Services
{
    public class CategoryService : _BaseService<Category>
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<Category> GetQuery()
        {
            return base.GetQuery().OrderBy(q => q.Id);
        }

        public void Create(Category category)
        {
            using (var transaction = this.GetTransaction())
            {
                this.unitOfWork.repository.Insert(category);                
                this.unitOfWork.Commit();
            }
        }

        public List<CategoryViewModel> GetAllCategoryView()
        {
            return this.GetQuery()
                .OrderBy(q => q.Name)
                .OrderByDescending(q => q.ArticleCategoryMapping.Count)
                .ToList().Select(q => new CategoryViewModel(q)).ToList();
        }
    }
}
