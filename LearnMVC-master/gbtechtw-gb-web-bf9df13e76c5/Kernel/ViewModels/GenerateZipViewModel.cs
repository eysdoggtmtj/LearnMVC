namespace Kernel.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GenerateZipViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public List<ArchiveViewModel> Archives { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        public List<string> PageUrl { get; set; }
    }
}
