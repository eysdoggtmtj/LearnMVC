namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyArticle : _BaseModel
    {
        //建立文章資料表：文章標題Title、文章內容Content、文章類別MyClass
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }

        public int MyClassId { get; set; }
        [ForeignKey("MyClassId")]
        public MyClass MyClass { get; set; }
    }
}
