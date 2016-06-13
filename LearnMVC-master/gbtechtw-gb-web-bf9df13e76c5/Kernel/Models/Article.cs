namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article : _BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string UrlTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsMarkdown { get; set; }

        public virtual ICollection<ArticleCategoryMapping> ArticleCategoryMapping { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }        
    }
}
