﻿namespace Kernel.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SidebarViewModel
    {
        public SidebarViewModel()
        {

        }

        public List<CategoryViewModel> Categories { get; set; }

        public List<ArchiveViewModel> Archives { get; set; }
    }
}
