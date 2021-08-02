using CancerAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.Mappings
{
    public static class CategoryMappings
    {
        public static CategoryViewModel MapDtoToViewModel (Category dto)
        {
            return new CategoryViewModel
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Category MapViewModelToDto(CategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }
    }
}
