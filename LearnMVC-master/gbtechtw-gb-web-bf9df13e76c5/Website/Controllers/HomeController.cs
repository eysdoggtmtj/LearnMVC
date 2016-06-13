namespace Website.Controllers
{
    using Kernel.DAL;
    using Kernel.Models;
    using Kernel.Services;
    using Kernel.ViewModels;
    using Website;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Kernel.Migrations;
    public class HomeController : BaseController
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

        }

        /*
         * public ActionResult Index()
        {
            using (var transaction = this.StoreService.GetTransaction())
            {
                var store = new Store { Name = "MR.COFFEE2", Latitude = 16, Longitude = 38 };
                this.StoreService.Create(store);
                transaction.Commit();

            }
            return this.ReturnJson(this.StoreService.GetQuery().ToList());
        }
        */

    }
}