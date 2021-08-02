using System.Threading.Tasks;
using CancerAM.Models;
using CancerAM.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CancerAM.ViewComponents
{
    public class AdminArticleEditViewComponent : ViewComponent
    {
        public AdminArticleEditViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync(AdminArticleEditViewModel model) => View(model);
    }
}