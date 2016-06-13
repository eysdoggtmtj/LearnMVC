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
    using System.Xml.Linq;
    using System.EnterpriseServices;
    using System.Security.Claims;
    using System.Data.Entity;
    public class HomeController : BaseController
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

        }

        public ActionResult Index()
        {
            using (var transaction = this.MyClassService.GetTransaction())
            {
                var myClass = new MyClass { Name = "TestClass" };

                MyArticle TestArticle1 = new MyArticle { Title = "TestArticle1", Content = "TEST", MyClassId = myClass.Id };
                myClass.MyArticles = new List<MyArticle>();
                myClass.MyArticles.Add(TestArticle1);
                this.MyClassService.Create(myClass);

                transaction.Commit();
            }
            return this.ReturnJson(this.MyClassService.GetQuery().Include(q=>q.MyArticles).ToList().Select(q=>new MyClassViewModel(q)));
        }
    }
}