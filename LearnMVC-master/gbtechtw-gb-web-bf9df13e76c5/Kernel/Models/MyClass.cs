namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyClass : _BaseModel
    {
        //建立類別資料表：類別名稱Name
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<MyArticle> MyArticles { get; set; }
    }
}
