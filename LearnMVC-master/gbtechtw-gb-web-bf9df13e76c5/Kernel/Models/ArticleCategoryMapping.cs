namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArticleCategoryMapping : _BaseModel
    {
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
