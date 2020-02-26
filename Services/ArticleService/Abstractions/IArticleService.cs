using netCoreWorkshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreWorkShop.Services.ArticleService.Abstractions
{
    public interface IArticleService
    {
        List<Article> GetArticles();

        Article GetArticle(int id);

        Article AddArticle(Article article);

        Article EditArticle(Article article); 

        void DeleteArticle(int id);
    }
}
