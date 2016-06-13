namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category : _BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string UrlName { get; set; }

        public virtual ICollection<ArticleCategoryMapping> ArticleCategoryMapping { get; set; }
    }
}
