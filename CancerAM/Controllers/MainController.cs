using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CancerAM.Models;
using CancerAM.Services;
using CancerAM.DAL;
using Microsoft.AspNetCore.Authorization;
using static CancerAM.Models.Enums;

namespace CancerAM.Controllers
{
    public class MainController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly ArticleService _articleService;

        public MainController(IUnitOfWork unitOfWork)
        {
            _categoryService = new CategoryService(unitOfWork);
            _articleService = new ArticleService(unitOfWork);
        }

        public IActionResult Index(int? categoryId, int? articleId)
        {
            if (categoryId.HasValue)
            {
                if (articleId.HasValue)
                {
                    var article = _articleService.GetArticle(articleId.Value);
                    string view = GetArticleViewString((CATEGORY_TYPE)article.Category.Id);
                    
                    return article.SubArticles != null && article.SubArticles.Any() ? View(view, article) : View();
                }

                var category = _categoryService.GetCategory(categoryId.Value, includeArticles: true);
                return View(GetTypesViewString((CATEGORY_TYPE)category.Id), category);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetTypesViewString(CATEGORY_TYPE categoryType) => categoryType switch
        {
            CATEGORY_TYPE.CANCER_TYPES => "Types",
            CATEGORY_TYPE.USEFUL_NEWS => "UsefulInfo",
            CATEGORY_TYPE.CLINICS => "Clinics",
            CATEGORY_TYPE.DOCTORS => "Doctors",
            CATEGORY_TYPE.NEW => "",
            CATEGORY_TYPE.BLOG => "",
            _ => string.Empty,
        };

        private string GetArticleViewString(CATEGORY_TYPE categoryType) => categoryType switch
        {
            CATEGORY_TYPE.CANCER_TYPES => "TypeInfo",
            CATEGORY_TYPE.USEFUL_NEWS => "UsefulInfo",
            CATEGORY_TYPE.CLINICS => "ClinicsInfo",
            CATEGORY_TYPE.DOCTORS => "DoctorInfo",
            CATEGORY_TYPE.NEW => "",
            CATEGORY_TYPE.BLOG => "",
            _ => string.Empty,
        };

    }
}
