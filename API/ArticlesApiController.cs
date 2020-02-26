using Microsoft.AspNetCore.Mvc;
using netCoreWorkshop.Entities;
using netCoreWorkShop.Services.ArticleService.Abstractions;
using System.Linq;

namespace netCoreWorkshop.API
{
    [Route("/api/articles")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesApiController(IArticleService articleServices)
        {
            _articleService = articleServices;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_articleService.GetArticles());


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var article = _articleService.GetArticle(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Article article)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newArticle = _articleService.AddArticle(article);

            return CreatedAtAction(nameof(Create), new { newArticle.Id }, newArticle);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = _articleService.GetArticle(id);

            if(article == null)
            {
                return NotFound();
            }

            _articleService.DeleteArticle(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Article article)
        {

            if (article.Id != id)
            {
                return BadRequest();

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var articleInList = _articleService.EditArticle(article);

            if (articleInList == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
