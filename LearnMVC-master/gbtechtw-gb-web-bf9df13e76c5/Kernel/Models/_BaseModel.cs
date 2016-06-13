namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class _BaseModel
    {
        public _BaseModel()
        {
            this.CreatedTime = DateTime.UtcNow.AddHours(8);
            this.ModifiedTime = this.CreatedTime;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
