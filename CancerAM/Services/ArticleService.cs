using CancerAM.DAL;
using CancerAM.Mappings;
using CancerAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CancerAM.DAL.Entities;
using CancerAM.Models.Admin.Article;

namespace CancerAM.Services
{
    public class ArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthorService _authorService;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _authorService = new AuthorService(unitOfWork);
        }

        public ArticleViewModel GetArticle(int id)
        {
            var articleDto = _unitOfWork.ArticleRepository.Get(id);

            if (articleDto != null)
            {
                var author = _authorService.GetAuthor(articleDto.AuthorId); ;
                var category = new CategoryService(_unitOfWork).GetCategory(articleDto.CategoryId);
                var subArticles = GetSubArticles(articleId: id);

                var article = ArticleMappings.MapDtoToViewModel(articleDto, author, category, subArticles);
                return article;
            }
            else
            {
                return null;
            }
        }

        public List<SubArticleViewModel> GetSubArticles(int articleId)
        {
            SubArticleViewModel toModel(SubArticle _) => SubArticleMappings.MapDtoToViewModel(_);
            var list = _unitOfWork.SubArticlesRepository.GetList(articleId)?.ConvertAll(toModel);

            return list;
        }

        public List<ArticleViewModel> GetArticles(int categoryId)
        {
            var authors = _authorService.GetAuthors();
            var category = new CategoryService(_unitOfWork).GetCategory(categoryId);
            ArticleViewModel toModel(Article _) 
                => ArticleMappings.MapDtoToViewModel(_, authors.FirstOrDefault(author => author.Id == _.AuthorId), category, null);

            var list = _unitOfWork.ArticleRepository.GetList(categoryId)?.ConvertAll(toModel);

            return list.OrderBy(_ => _.Position).ToList();
        }

        public void Create(int categoryId, ArticleCreateRequest request)
        {
            var downArticle = _unitOfWork.ArticleRepository
                .GetList(categoryId)
                .OrderByDescending(_ => _.Position)
                .Take(1)
                .FirstOrDefault();
            
            var newRecord = new Article
            {
                Body = request.Body,
                Title = request.Title,
                AuthorId = 2,
                CategoryId = categoryId,
                CreatedDate = DateTime.Now,
                ImgPath = request.Image,
            };

            if (downArticle is {Position: { }})
            {
                newRecord.Position = downArticle.Position.Value + 1;
            }
            
            _unitOfWork.ArticleRepository.Insert(newRecord);
        }

        public void Update(int categoryId, int articleId, ArticleUpdateRequest request)
        {
            var articleDTO = _unitOfWork.ArticleRepository.Get(articleId);

            if (articleDTO == null) throw new Exception();

            articleDTO.Body = request.Body ?? articleDTO.Body;
            articleDTO.Title = request.Title ?? articleDTO.Title;
            articleDTO.ImgPath = request.Image ?? articleDTO.ImgPath;
            articleDTO.SecondTitle = request.SecondTitle ?? articleDTO.SecondTitle;

            if (request.IsUp.HasValue || request.IsDown.HasValue)
            {
                Article previousArticle = null;

                if (request.IsUp.Value)
                {
                    previousArticle = _unitOfWork.ArticleRepository
                        .GetList(categoryId)
                        .FirstOrDefault(_ => _.Position == request.Position - 1);
                }

                if (request.IsDown.Value)
                {
                    previousArticle = _unitOfWork.ArticleRepository
                        .GetList(categoryId)
                        .FirstOrDefault(_ => _.Position == request.Position + 1);
                }
                
                if (previousArticle != null)
                {
                    // Update articles position
                    previousArticle.Position = articleDTO.Position;
                    previousArticle.Body = previousArticle.Body;
                    previousArticle.Title = previousArticle.Title;
                    previousArticle.ImgPath = previousArticle.ImgPath;
                    previousArticle.SecondTitle = previousArticle.SecondTitle;
                    
                    _unitOfWork.ArticleRepository.Update(previousArticle);
                    _unitOfWork.Save();
                }
                
                articleDTO.Position = request.IsUp.Value ? request.Position - 1 : request.Position + 1;
            }
            
            _unitOfWork.ArticleRepository.Update(articleDTO);
            _unitOfWork.Save();
        }

        public void Delete(int categoryId, int articleId)
        {
            var articleDTO = _unitOfWork.ArticleRepository.Get(articleId);

            if (articleDTO == null) throw new Exception();

            var subArticles = _unitOfWork.SubArticlesRepository.GetList(articleId);

            if (subArticles != null && subArticles.Count > 0)
            {
                foreach (var subArticle in subArticles)
                {
                    _unitOfWork.SubArticlesRepository.Delete(subArticle.Id);
                }
            }
            
            _unitOfWork.ArticleRepository.Delete(articleId);
        }
    }
}
