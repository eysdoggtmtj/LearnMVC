namespace Website.Controllers
{
    using Kernel.DAL;
    using Kernel.Models;
    using Kernel.Services;
    using Kernel.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public abstract class BaseController : Controller
    {
        public StoreService StoreService;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var dbContert = new ApplicationDbContext();
            this.StoreService = new StoreService(dbContert);
        }

        protected JsonResult ReturnJson(object obj, bool success = true, object ErrorMessage = null, object error = null)
        {
            return this.Json(new
            {
                success = success,
                data = obj,
                errorMsg = ErrorMessage,
                error = error
            }, JsonRequestBehavior.AllowGet);
        }

    }
}