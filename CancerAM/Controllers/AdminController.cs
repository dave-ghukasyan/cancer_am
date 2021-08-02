using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CancerAM.DAL;
using CancerAM.Models;
using CancerAM.Models.Admin;
using CancerAM.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CancerAM.Controllers
{
    public class AdminController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly ArticleService _articleService;
        private readonly AuthorService _authorService;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _categoryService = new CategoryService(unitOfWork);
            _articleService = new ArticleService(unitOfWork);
            _authorService = new AuthorService(unitOfWork);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var author = _authorService
                .GetAuthors()
                .FirstOrDefault(_ => _.Password == request.Password && _.Username == request.Username);

            if (author == null)
            {
                TempData["login_failed"] = "Invalid username or/and password.";
                return RedirectToAction("Login");
            }
            
            var adminClaims = new List<Claim>()
            {
                new Claim("userId", author.Id.ToString()),
                new Claim(ClaimTypes.Name, author.FullName),
            };

            var adminIdentity = new ClaimsIdentity(adminClaims, "Admin Identity");
            var userPrincipal = new ClaimsPrincipal(new[] {adminIdentity});

            await HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        
        [Authorize]
        public IActionResult Index(int? currentCategoryId, int? currentArticleId, int? currentSubArticleId)
        {
            var categories = _categoryService.GetCategories();
            
            var currentCategory = currentCategoryId.HasValue
                ? _categoryService.GetCategory(currentCategoryId.Value, includeArticles: false)
                : null;
            
            var currentArticle = currentArticleId.HasValue 
                ? _articleService.GetArticle(currentArticleId.Value) 
                : null;

            var currentSubArticle = currentSubArticleId.HasValue 
                                    && currentArticle is {SubArticles: { }} // Contains Sub Articles
                                    && currentArticle.SubArticles.Any(_ => _.Id == currentSubArticleId.Value)
                ? currentArticle.SubArticles.FirstOrDefault(_ => _.Id == currentSubArticleId.Value)
                : null; 
            
            return View(new AdminContentViewModel 
            {
                Categories = categories,
                CurrentCategoryId = currentCategoryId,
                CurrentArticleId = currentArticleId,
                CurrentSubArticleId = currentSubArticleId,
                CurrentCategoryName = currentCategory?.Name,
                CurrentArticle = currentArticle,
                CurrentSubArticle = currentSubArticle
            });
        }
    }
}
