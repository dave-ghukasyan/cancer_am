using System;
using CancerAM.DAL;
using CancerAM.DAL.Entities;
using CancerAM.Mappings;
using CancerAM.Models;
using CancerAM.Models.Admin.SubArticle;

namespace CancerAM.Services
{
    public class SubArticleService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArticleService _articleService;
        
        public SubArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _articleService = new ArticleService(unitOfWork);
        }

        public SubArticleViewModel Update(int articleId, int subArticleId, SubArticleUpdateRequest request)
        {
            var articleDTO = _unitOfWork.ArticleRepository.Get(articleId);

            if (articleDTO == null)
                throw new Exception();
            
            var existingSubArticle = _unitOfWork.SubArticlesRepository.Get(subArticleId);

            if (existingSubArticle == null || request == null)
            {
                return null;
            }

            existingSubArticle.Title = request.Title ?? existingSubArticle.Title;
            existingSubArticle.Body = request.Body ?? existingSubArticle.Body;
            
            _unitOfWork.SubArticlesRepository.Update(existingSubArticle);
            _unitOfWork.Save();
            
            //Update Modified date
            articleDTO.ModifiedDate = DateTime.Now;
            _unitOfWork.ArticleRepository.Update(articleDTO);
            _unitOfWork.Save();

            return SubArticleMappings.MapDtoToViewModel(existingSubArticle);
        }

        public SubArticleViewModel Create(int categoryId, int articleId, SubArticleCreateRequest request)
        {
            var articleDTO = _unitOfWork.ArticleRepository.Get(articleId);

            if (articleDTO == null)
                throw new Exception();
            
            var newRecord = new SubArticle()
            {
                Title = request.Title,
                Body = request.Body,
                ArticleId = articleId
            };

            _unitOfWork.SubArticlesRepository.Insert(newRecord);
            
            //Update Modified date
            articleDTO.ModifiedDate = DateTime.Now;
            _unitOfWork.ArticleRepository.Update(articleDTO);
            _unitOfWork.Save();

            return SubArticleMappings.MapDtoToViewModel(newRecord);
        }

        public void Delete(int categoryId, int articleId, int subArticleId)
        {
            var articleDTO = _unitOfWork.ArticleRepository.Get(articleId);
            
            if (articleDTO == null)
                throw new Exception();
            
            var existingSubArticle = _unitOfWork.SubArticlesRepository.Get(subArticleId);

            if (existingSubArticle == null)
                throw new Exception();
            
            _unitOfWork.SubArticlesRepository.Delete(subArticleId);

            //Update Modified date
            articleDTO.ModifiedDate = DateTime.Now;
            _unitOfWork.ArticleRepository.Update(articleDTO);
            _unitOfWork.Save();
        }
    }
}