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
        public CategoryService categoryService { get; set; }

        public ArticleService articleService { get; set; }

        public string SiteUrl { get; private set; }
        public string PublishSiteUrl = "http://sudo.tw";
        public string SitePath { get; private set; }
        public bool IsDebug
        {
            get
            {
#if DEBUG
                return true;
#endif
                return false;
            }
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var blogDbContext = new ApplicationDbContext();
            this.categoryService = new CategoryService(blogDbContext);
            this.articleService = new ArticleService(blogDbContext);
            this.SiteUrl = this.Request.Url.AbsoluteUri.Substring(0, this.Request.Url.AbsoluteUri.Length - this.Request.Url.PathAndQuery.Length);
            this.SitePath = Server.MapPath("~/");
            ViewBag.PublishSiteUrl = this.PublishSiteUrl;
            ViewBag.PageUrl = this.PublishSiteUrl + Request.Url.AbsolutePath;
            ViewBag.IsDebug = this.IsDebug;
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