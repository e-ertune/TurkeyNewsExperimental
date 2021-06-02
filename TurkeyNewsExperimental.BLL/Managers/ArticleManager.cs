using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TurkeyNewsExperimental.BLL.Services;
using TurkeyNewsExperimental.Model.Models;

namespace TurkeyNewsExperimental.BLL.Managers
{
    public class ArticleManager : IArticleService
    {
        public List<Article> GetArticles(string apiUri)
        {
            List<Article> articles = new List<Article>();
            using (var reader = new StreamReader(HttpWebRequest.CreateHttp(apiUri).GetResponse().GetResponseStream()))
            {
                JObject json = JObject.Parse(JsonConvert.DeserializeObject(reader.ReadToEnd()).ToString());
                foreach (var item in json["articles"])
                {
                    Article article = new Article();
                    article.SourceName = item["source"]["name"].ToString();
                    article.Title = item["title"].ToString();
                    article.PublishedAt = DateTime.Parse(item["publishedAt"].ToString());
                    article.Url = item["url"].ToString();
                    article.Author = item["author"].ToString();
                    article.Description = item["description"].ToString();
                    article.UrlToImage = item["urlToImage"].ToString();
                    article.Content = item["content"].ToString();
                    articles.Add(article);
                }
            }
            return articles;
        }
    }
}
