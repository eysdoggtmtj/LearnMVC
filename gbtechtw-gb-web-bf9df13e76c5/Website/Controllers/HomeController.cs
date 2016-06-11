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

    public class HomeController : BaseController
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ViewBag.Title = "Enjoy Your Coding - Eric Ping(王致平)";
            ViewBag.Description = "歡迎來到EricPing的程式小屋﻿，HTML5, CSS3, JavaScript, jQuery, AngularJS, Git, Java, CSharp, ASP.NET MVC, PHP, Database, Android, Windows, Azure, Linux, MacOS, LINQ, NodeJS, Other";
            ViewBag.Keywords = "Enjoy Your Coding - Eric Ping, EricPing, Enjoy Your Coding,HTML5, CSS3, JavaScript, jQuery, AngularJS, Git, Java, CSharp, ASP.NET MVC, PHP, Database, Android, Windows, Azure, Linux, MacOS, LINQ, NodeJS, Other";
        }

        public ActionResult Index()
        {
            return this.Page(1);
        }

        public ActionResult All()
        {
            var list = this.articleService.GetQuery().ToList().Select(q => new ArticleViewModel(q)).ToList();
            var model = new PageViewModel { Articles = list };
            return View("Index", model);
        }

        public ActionResult Page(int page)
        {
            int limit = Config.ArticleCountPerPage;
            int totalPage = (int)Math.Ceiling((double)this.articleService.GetQuery().Count() / limit);
            int offset = (page - 1) * limit;
            var list = this.articleService.GetQuery().Skip(offset).Take(limit).ToList().Select(q => new ArticleViewModel(q)).ToList();
            var model = new PageViewModel { Articles = list, CurrentPage = page, TotalPage = totalPage };

            int count = Config.PageBarCount;
            if (totalPage <= count)
            {
                model.StartPage = 1;
                model.EndPage = totalPage;
            }
            else
            {
                int diff = (int)Math.Floor((double)count / 2);
                var pageList = new List<int>();

                for (int i = page - diff; i <= page + diff; i++)
                {
                    pageList.Add(i);
                }

                if (pageList.Any(q => q < 1))
                {
                    int addBack = 1 - pageList.Min();
                    for (int i = 0; i < pageList.Count; i++)
                    {
                        pageList[i] += addBack;
                    }
                }
                else if (pageList.Any(q => q > totalPage))
                {
                    int minusBack = pageList.Max() - totalPage;
                    for (int i = 0; i < pageList.Count; i++)
                    {
                        pageList[i] -= minusBack;
                    }
                }

                model.StartPage = pageList.Min();
                model.EndPage = pageList.Max();
            }
            return View("Index", model);
        }

        public ActionResult Detail(string name)
        {
            this.ViewBag.IsDetail = true;
            var article = new ArticleViewModel(this.articleService.GetQuery().First(q => q.UrlTitle == name));
            ViewBag.Title = article.Title + " - " + ViewBag.Title;
            ViewBag.Description = Regex.Replace(article.Description
                .Replace("\n", string.Empty).Replace(" ", string.Empty), @"<[^>]*>", String.Empty)
                + " - " + ViewBag.Title;
            ViewBag.Keywords = ViewBag.Keywords + ", " + string.Join(", ", article.Keywords.Select(q => q.Name).ToList());
            return View("BlogPosting", article);
        }

        public ActionResult Archive(int year, int month)
        {
            var list = this.articleService.GetQuery()
                .Where(q => q.CreatedTime.Year == year && q.CreatedTime.Month == month).ToList()
                .Select(q => new ArticleViewModel(q)).ToList();

            var model = new PageViewModel { Articles = list };
            return View("Index", model);
        }


        public ActionResult Category(string name)
        {
            var list = this.categoryService.GetQuery().FirstOrDefault(q => q.UrlName == name)
                .ArticleCategoryMapping
                .OrderByDescending(q => q.Article.CreatedTime)
                .Select(q => new ArticleViewModel(q.Article)).ToList();
            var model = new PageViewModel { Articles = list };
            return View("Index", model);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebar()
        {
            var categoryList = this.categoryService.GetAllCategoryView();

            var archiveList = this.articleService.GetArchiveList();

            var model = new SidebarViewModel { Categories = categoryList, Archives = archiveList };

            return PartialView(model);
        }
    }
}