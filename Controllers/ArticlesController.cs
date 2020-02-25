using Microsoft.AspNetCore.Mvc;
using netCoreWorkshop.Entities;
using System.Linq;

namespace netCoreWorkshop.Controllers
{
    public class ArticlesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Article.DataSource);
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

            article.Id = Article.DataSource.Count() + 1;
            Article.DataSource.Add(article);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var article = Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

            if (article != null)
            {
                Article.DataSource.Remove(article);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var article = Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

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

            var articleInList = Article.DataSource.Where(a => a.Id == article.Id).FirstOrDefault();

            if (articleInList != null)
            {
                articleInList.Title = article.Title;
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

            var article = Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

            if (article == null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }
    }
}