using Microsoft.AspNetCore.Mvc;
using netCoreWorkshop.Entities;
using netCoreWorkShop.Services.ArticleService.Abstractions;
using System.Linq;

namespace netCoreWorkshop.Controllers
{
    public class ArticlesController : Controller
    {

        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_articleService.GetArticles());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("TitleError", "Debes ingresar un titulo");
                return View();
            }

            _articleService.AddArticle(article);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var article = _articleService.GetArticle((int)id);

            if (article == null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var article = _articleService.GetArticle(id);

            if (article != null)
            {
                _articleService.DeleteArticle(id);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var article = _articleService.GetArticle((int)id);

            if (article == null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult ConfirmEdit(Article article)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("TitleError", "Debes ingresar un titulo");
                return View(article);
            }

            _articleService.EditArticle(article);

            return RedirectToAction("Index");
        }
    }
}