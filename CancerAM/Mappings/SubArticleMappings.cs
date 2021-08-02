using System;
using CancerAM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.Mappings
{
    public static class SubArticleMappings
    {
        public static SubArticleViewModel MapDtoToViewModel(SubArticle dto)
        {
            return new SubArticleViewModel
            {
                Id = dto.Id,
                Body = dto.Body,
                Title = dto.Title,
            };
        }
    }
}
