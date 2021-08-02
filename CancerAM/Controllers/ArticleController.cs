using CancerAM.DAL;
using CancerAM.Models.Admin.Article;
using CancerAM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CancerAM.Controllers
{
    [ApiController]
    [Route("[controller]/{categoryId:int}/")]
    public class ArticleController : Controller
    {
        private readonly ArticleService _articleService;
        
        public ArticleController(IUnitOfWork unitOfWork)
        {
            _articleService = new ArticleService(unitOfWork);
        }
        
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post(
            int categoryId,
            int articleId,
            ArticleCreateRequest request)
        {
            if (request.Title == null)
                return BadRequest();

            try
            {
                _articleService.Create(categoryId, request);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        [Consumes("application/json")]
        [Route("{articleId:int}")]
        public IActionResult Put(
            int categoryId, 
            int articleId, 
            int subArticleId,
            ArticleUpdateRequest request) 
        {
            try
            {
                _articleService.Update(categoryId, articleId, request);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        [Route("{articleId:int}")]
        public IActionResult Delete(
            int categoryId, 
            int articleId)
        {
            try
            {
                _articleService.Delete(categoryId, articleId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}