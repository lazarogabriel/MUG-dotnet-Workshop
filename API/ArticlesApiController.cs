using Microsoft.AspNetCore.Mvc;
using netCoreWorkshop.Entities;
using System.Linq;

namespace netCoreWorkshop.API
{
    [Route("/api/articles")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(Article.DataSource.ToList());


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var article = Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

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

            var newArticle = new Article { Title = article.Title, Id = Article.DataSource.Count() + 1 };

            Article.DataSource.Add(newArticle);

            return CreatedAtAction(nameof(Create), new { newArticle.Id }, newArticle);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = Article.DataSource.Where(a => a.Id == id).FirstOrDefault();

            if(article == null)
            {
                return NotFound();
            }

            Article.DataSource.Remove(article);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody]Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var articleInList = Article.DataSource.Where(a => a.Id == article.Id).FirstOrDefault();

            if (articleInList == null)
            {
                return NotFound();
            }

            articleInList.Title = article.Title;

            return Ok();
        }
    }
}
