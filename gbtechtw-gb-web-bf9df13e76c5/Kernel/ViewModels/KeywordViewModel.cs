namespace Kernel.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class KeywordViewModel
    {
        public KeywordViewModel()
        {

        }

        public KeywordViewModel(Keyword keyword) : this()
        {
            this.Id = keyword.Id;
            this.Name = keyword.Name;
            this.ArticleId = keyword.ArticleId;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int ArticleId { get; set; }
    }
}
