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
    public class MyArticleService : _BaseService<MyArticle>
    {
        public MyArticleService(ApplicationDbContext context) : base(context)
        {
        }

        public static implicit operator MyArticleService(List<MyArticle> v)
        {
            throw new NotImplementedException();
        }
    }
}
