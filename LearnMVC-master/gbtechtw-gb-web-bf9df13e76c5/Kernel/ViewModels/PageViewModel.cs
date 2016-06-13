namespace Kernel.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PageViewModel
    {
        public PageViewModel()
        {

        }

        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public List<ArticleViewModel> Articles { get; set; }
    }
}
