namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Keyword : _BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
