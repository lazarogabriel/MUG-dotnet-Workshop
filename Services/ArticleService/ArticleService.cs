using Microsoft.Extensions.Logging;
using netCoreWorkshop.Entities;
using netCoreWorkShop.Data;
using netCoreWorkShop.Services.ArticleService.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace netCoreWorkShop.Services.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly ArticlesContext _context;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(ArticlesContext context, ILogger<ArticleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Article AddArticle(Article article)
        {
            _logger.LogDebug("Starting store an article");

            var newArticle = new Article { Title = article.Title };
            _context.Articles.Add(newArticle);
            _context.SaveChanges();

            _logger.LogDebug("Ending store an article");

            return article;
        }

        public Article GetArticle(int id) => _context.Articles.SingleOrDefault(a => a.Id == id);

        public List<Article> GetArticles() => _context.Set<Article>().ToList();


        public Article EditArticle(Article article)
        {
            var articleInList = GetArticle(article.Id);

            articleInList.Title = article.Title;
            _context.SaveChanges();

            return article;
        }

        public void DeleteArticle(int id)
        {
            var article = GetArticle(id);

            _context.Remove(article);
            _context.SaveChanges();
        }

    }
}
