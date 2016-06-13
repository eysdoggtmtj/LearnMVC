using Kernel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Controllers;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Kernel.Helpers;

namespace Website.Areas.Admin.Controllers
{
    public class GenerateController : BaseController
    {
        // GET: Admin/Generate
        public ActionResult Zip()
        {
            var model = new GenerateZipViewModel();

            model.Articles = this.articleService.GetQuery().ToList().Select(q => new ArticleViewModel(q)).ToList();

            model.Archives = this.articleService.GetArchiveList();

            model.Categories = this.categoryService.GetAllCategoryView();

            int limit = Config.ArticleCountPerPage;
            int totalPage = (int)Math.Ceiling((double)this.articleService.GetQuery().Count() / limit);

            model.PageUrl = new List<string>() { "/", "/All/" };
            for (int i = 1; i <= totalPage; i++)
            {
                model.PageUrl.Add("/Page/" + i.ToString() + "/");
            }


            string publishFolder = this.SitePath + "_Publish";
            if (Directory.Exists(publishFolder))
            {
                Directory.Delete(publishFolder, true);
            }

            Directory.CreateDirectory(publishFolder);

            #region Copy publish folder
            var CopyDirs = new List<string>() { "public", "files" };
            CopyDirs.ForEach(dir =>
            {
                try
                {
                    string sourcePublicFolderPath = this.SitePath + dir;
                    string destinationPublishFolderPath = publishFolder + "/" + dir;
                    var sourceDirectory = Directory.GetDirectories(sourcePublicFolderPath, "*",
                        SearchOption.AllDirectories);

                    foreach (string dirPath in Directory.GetDirectories(sourcePublicFolderPath, "*",
                        SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(sourcePublicFolderPath, destinationPublishFolderPath));
                    }

                    foreach (var filePath in Directory.GetFiles(sourcePublicFolderPath, "*",
                        SearchOption.AllDirectories))
                    {
                        System.IO.File.Copy(filePath, filePath.Replace(sourcePublicFolderPath, destinationPublishFolderPath));
                    }
                }
                catch (Exception)
                {
                    // TODO: 之後再來看看要怎麼做例外處理吧
                }
            });

            #endregion

            #region Generate Archive, Article, Category, Page Path, SiteMap           

            var siteMapGenerator = new SiteMapGenerator(publishFolder + "/sitemap.xml");

            model.Articles.ForEach(article =>
            {
                Directory.CreateDirectory(publishFolder + article.Url);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string content = client.DownloadString(this.SiteUrl + article.Url);
                    System.IO.File.WriteAllText(publishFolder + article.Url + "index.html", content, Encoding.UTF8);
                    siteMapGenerator.PutUrl(this.PublishSiteUrl + article.Url, "monthly", 1.0);
                }
            });

            model.Categories.ForEach(category =>
            {
                Directory.CreateDirectory(publishFolder + category.Url);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string content = client.DownloadString(this.SiteUrl + category.Url);
                    System.IO.File.WriteAllText(publishFolder + category.Url + "index.html", content, Encoding.UTF8);
                    siteMapGenerator.PutUrl(this.PublishSiteUrl + category.Url, "monthly", 0.8);
                }
            });

            model.Archives.ForEach(archive =>
            {
                Directory.CreateDirectory(publishFolder + archive.Url);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string content = client.DownloadString(this.SiteUrl + archive.Url);
                    System.IO.File.WriteAllText(publishFolder + archive.Url + "index.html", content, Encoding.UTF8);
                    siteMapGenerator.PutUrl(this.PublishSiteUrl + archive.Url, "monthly", 0.5);
                }
            });

            model.PageUrl.ForEach(url =>
            {
                Directory.CreateDirectory(publishFolder + url);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string content = client.DownloadString(this.SiteUrl + url);
                    System.IO.File.WriteAllText(publishFolder + url + "index.html", content, Encoding.UTF8);
                    siteMapGenerator.PutUrl(this.PublishSiteUrl + url, "monthly", 0.3);                    
                }
            });

            siteMapGenerator.Save();

            #endregion

            #region robots.txt

            string robots = "User-agent: *\r\nDisallow:\r\nSitemap: " + this.PublishSiteUrl + "/sitemap.xml";

            System.IO.File.WriteAllText(publishFolder + "/robots.txt", robots);

            //System.IO.File.WriteAllText(publishFolder + "/.htaccess", "Options -Indexes", Encoding.UTF8);


            #endregion

            return this.ReturnJson(model);
        }
    }
}