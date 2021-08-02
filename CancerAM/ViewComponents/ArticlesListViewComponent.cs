using System.Threading.Tasks;
using CancerAM.DAL;
using CancerAM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CancerAM.ViewComponents
{
    public class ArticlesListViewComponent : ViewComponent
    {
        private readonly ArticleService _articleService;

        public ArticlesListViewComponent(IUnitOfWork unitOfWork)
        {
            _articleService = new ArticleService(unitOfWork);
        }

        public async Task<IViewComponentResult> InvokeAsync(int currentCategoryId)
        {
            var articles = _articleService.GetArticles(currentCategoryId);
            return View(articles);
        }
    }
}