using Kernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.ViewModels
{

    public class MyClassViewModel
    {
        public MyClassViewModel(MyClass myClass)
        {
            this.Id = myClass.Id;
            this.Name = myClass.Name;
            this.MyArticles = myClass.MyArticles.Select(q =>
             {
                 return new MyArticleViewModel
                 {
                     Id = q.Id,
                     Title = q.Title
                 };
             }).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<MyArticleViewModel> MyArticles;
    }

    public class MyArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
