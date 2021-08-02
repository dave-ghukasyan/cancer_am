using CancerAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.Mappings
{
    public class ArticleMappings
    {
        public static ArticleViewModel MapDtoToViewModel(Article dto, AuthorViewModel author, CategoryViewModel category, List<SubArticleViewModel> subArticles)
        {
            return new ArticleViewModel
            {
                Id = dto.Id,
                Author = author,
                Category = category,
                Body = dto.Body,
                Title = dto.Title,
                Image = dto.ImgPath,
                CreatedDate = dto.CreatedDate,
                ModifiedDate = dto.ModifiedDate,
                SecondTitle = dto.SecondTitle,
                SubArticles = subArticles,
                Position = dto.Position
            };
        }

        public static Article MapViewModelToDto(ArticleViewModel viewModel)
        {
            return new Article
            {
                Id = viewModel.Id,
                AuthorId = viewModel.Author.Id,
                Body = viewModel.Body,
                ImgPath = viewModel.Image,
                CategoryId = viewModel.Category.Id,
                CreatedDate = viewModel.CreatedDate,
                ModifiedDate = viewModel.ModifiedDate,
                Title = viewModel.Title,
                SecondTitle = viewModel.SecondTitle,
                Position = viewModel.Position
            };
        }

    }
}
