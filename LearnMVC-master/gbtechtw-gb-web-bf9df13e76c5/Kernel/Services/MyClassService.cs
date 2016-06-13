using Kernel.DAL;
using Kernel.Models;
using Kernel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Services
{
    public class MyClassService : _BaseService<Store>
    {
        public MyClassService(ApplicationDbContext context) : base(context)
        {
        }

    }
}
