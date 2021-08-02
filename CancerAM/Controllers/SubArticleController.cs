using CancerAM.DAL;
using CancerAM.Models.Admin.SubArticle;
using CancerAM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CancerAM.Controllers
{
    [ApiController]
    [Route("[controller]/{categoryId:int}/{articleId:int}/")]
    public class SubArticleController : Controller
    {
        private readonly SubArticleService _subArticleService;
        
        public SubArticleController(IUnitOfWork unitOfWork)
        {
            _subArticleService = new SubArticleService(unitOfWork);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post(
            int categoryId,
            int articleId,
            SubArticleCreateRequest request)
        {
            if (request?.Body == null || request.Title == null)
                return BadRequest();

            try
            {
                _subArticleService.Create(categoryId, articleId, request);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [Route("{subArticleId:int}")]
        public IActionResult Put(
            int categoryId, 
            int articleId, 
            int subArticleId,
            SubArticleUpdateRequest request ) 
        {
            try
            {
                _subArticleService.Update(articleId, subArticleId, request);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        [Route("{subArticleId:int}")]
        public IActionResult Delete(
            int categoryId, 
            int articleId, 
            int subArticleId)
        {
            try
            {
                _subArticleService.Delete(categoryId, articleId, subArticleId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}