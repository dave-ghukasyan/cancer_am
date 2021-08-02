using System.Threading.Tasks;
using CancerAM.DAL;
using CancerAM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CancerAM.ViewComponents
{
    public class AdminCategoriesListViewComponent : ViewComponent
    {
        private readonly CategoryService _categoryService;
        
        public AdminCategoriesListViewComponent(IUnitOfWork unitOfWork)
        {
            _categoryService = new CategoryService(unitOfWork);
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
    }
}