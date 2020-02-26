using netCoreWorkshop.Entities;
using netCoreWorkShop.Services.ArticleService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace netCoreWorkShop.Services.ArticleService
{
    public class ArticleService : IArticleService
    {
        public Article AddArticle(Article article)
        {
            article.Id = Article.DataSource.Count();

            Article.DataSource.Add(article);

            return article;
        }

        public Article GetArticle(int id) => Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

        public List<Article> GetArticles() => Article.DataSource;


        public Article EditArticle(Article article)
        {
            var articleInList = GetArticle(article.Id);

            articleInList.Title = article.Title;

            return article;
        }

        public void DeleteArticle(int id)
        {
            var article = GetArticle(id);

            Article.DataSource.Remove(article);
        }


    }
}
