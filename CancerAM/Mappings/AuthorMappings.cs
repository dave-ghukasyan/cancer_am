using CancerAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.Mappings
{
    public static class AuthorMappings
    {
        public static AuthorViewModel MapDtoToViewModel(Author dto)
        {
            return new AuthorViewModel
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                IsSuperUser = dto.IsSuperuser,
                Username = dto.UserName,
            };
        }

        public static Author MapViewModelToDto(AuthorViewModel viewModel)
        {
            return new Author
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = viewModel.Password,
                IsSuperuser = viewModel.IsSuperUser
            };
        }
    }
}
