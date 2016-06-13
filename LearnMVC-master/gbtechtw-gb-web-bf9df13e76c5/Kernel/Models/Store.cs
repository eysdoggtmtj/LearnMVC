namespace Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Store : _BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
