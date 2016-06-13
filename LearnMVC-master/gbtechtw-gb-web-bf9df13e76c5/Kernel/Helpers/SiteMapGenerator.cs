namespace Kernel.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    public class SiteMapGenerator
    {
        private string FilePath { get; set; }
        private XmlDocument Document { get; set; }
        private XmlElement UrlSet { get; set; }

        public SiteMapGenerator(string path)
        {
            this.FilePath = path;
            this.Document = new XmlDocument();
            this.Document.AppendChild(this.Document.CreateXmlDeclaration("1.0", "UTF-8", null));
            this.UrlSet = this.Document.CreateElement("urlset");
            this.UrlSet.SetAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            this.UrlSet.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            this.UrlSet.SetAttribute("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9             http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
        }

        public void PutUrl(string url, string changefreq, double priority)
        {
            XmlElement urlElement = this.Document.CreateElement("url");
            XmlElement locElement = this.Document.CreateElement("loc");
            XmlElement changefreqElement = this.Document.CreateElement("changefreq");
            XmlElement priorityElement = this.Document.CreateElement("priority");
            locElement.InnerText = url;
            changefreqElement.InnerText = changefreq;
            priorityElement.InnerText = priority.ToString("0.00");
            urlElement.AppendChild(locElement);
            urlElement.AppendChild(changefreqElement);
            urlElement.AppendChild(priorityElement);
            this.UrlSet.AppendChild(urlElement);
        }

        public void Save()
        {
            this.Document.AppendChild(this.UrlSet);
            this.Document.Save(this.FilePath);
        }
    }
}
