namespace Kernel.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArchiveViewModel
    {
        public ArchiveViewModel()
        {

        }

        public int Year { get; set; }

        public int Month { get; set; }

        public string Name
        {
            get
            {
                return Year + "-" + Month.ToString("00");
            }
        }

        public string Url
        {
            get
            {
                return "/Archive/" + this.Name.Replace("-", "/") + "/";
            }
        }

    }
}
