namespace Kernel.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArticleViewModel
    {
        public ArticleViewModel()
        {

        }

        public ArticleViewModel(Article article) : this()
        {
            this.Id = article.Id;
            this.Title = article.Title;
            this.UrlTitle = article.UrlTitle;
            this.Description = article.Description;
            this.Content = article.Content;
            this.IsMarkdown = article.IsMarkdown;
            this.CreatedTime = article.CreatedTime;
            this.ModifiedTime = article.ModifiedTime;
            this.Categories = article.ArticleCategoryMapping.Select(q => new CategoryViewModel(q.Category)).ToList();
            this.Keywords = article.Keywords.Select(q => new KeywordViewModel(q)).ToList();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string UrlTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsMarkdown { get; set; }

        public DateTime CreatedTime { get; set; }

        public string CreatedTimeFormat
        {
            get
            {
                return this.CreatedTime.ToString();
            }
        }

        public DateTime ModifiedTime { get; set; }

        public string ModifiedTimeFormat
        {
            get
            {
                return this.ModifiedTime.ToString();
            }
        }

        public string Url
        {
            get
            {
                return string.Format("/Article/{0}/", this.UrlTitle);
            }
        }

        public List<CategoryViewModel> Categories { get; set; }

        public List<KeywordViewModel> Keywords { get; set; }
    }
}
