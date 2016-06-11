namespace Kernel.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }

        public CategoryViewModel(Category category) : this()
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.UrlName = category.UrlName;
            this.Count = category.ArticleCategoryMapping.Count;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string UrlName { get; set; }

        public string Url
        {
            get
            {
                return string.Format("/Category/{0}/", this.UrlName);
            }
        }

        public int Count { get; set; }
    }
}
