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
    public class ArticleService : _BaseService<Article>
    {
        public ArticleService(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<Article> GetQuery()
        {
            return base.GetQuery().OrderByDescending(q => q.CreatedTime);
        }

        public void Create(Article article)
        {
            using (var transaction = this.GetTransaction())
            {
                this.unitOfWork.repository.Insert(article);
                this.unitOfWork.Commit();
            }
        }

        public List<ArchiveViewModel> GetArchiveList()
        {
            return this.GetQuery().Select(q => new ArchiveViewModel { Year = q.CreatedTime.Year, Month = q.CreatedTime.Month })
                    .Distinct().ToList().OrderByDescending(q => q.Url).ToList();
        }
    }
}
