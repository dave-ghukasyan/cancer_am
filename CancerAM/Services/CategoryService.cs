using CancerAM.DAL;
using CancerAM.Mappings;
using CancerAM.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArticleService _articleService;

        public CategoryService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _articleService = new ArticleService(unitOfWork);
        }

        public CategoryViewModel GetCategory(int id, bool includeArticles = false)
        {
            var categoryDTO = _unitOfWork.CategoryRepository.Get(id);

            if (categoryDTO != null)
            {
                var category = CategoryMappings.MapDtoToViewModel(categoryDTO);

                if (includeArticles)
                {
                    category.Articles = _articleService.GetArticles(categoryId: id);
                }

                return category;
            }

            return null;
        }
            
        public List<CategoryViewModel> GetCategories() 
            => _unitOfWork.CategoryRepository.GetList().ConvertAll(_ => CategoryMappings.MapDtoToViewModel(_));
    }
}
