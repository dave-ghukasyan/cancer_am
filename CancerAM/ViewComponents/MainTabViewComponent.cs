using CancerAM.DAL;
using CancerAM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.ViewComponents
{
    public class MainTabViewComponent : ViewComponent
    {
        private readonly CategoryService _categoryService;

        public MainTabViewComponent(IUnitOfWork unitOfWork)
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
