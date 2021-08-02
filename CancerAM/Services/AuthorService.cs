using CancerAM.DAL;
using CancerAM.Mappings;
using CancerAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.Services
{
    public class AuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthorViewModel GetAuthor(int id)
        {
            var authorDto = _unitOfWork.AuthorRepository.Get(id);
            return AuthorMappings.MapDtoToViewModel(authorDto);
        }

        public List<AuthorViewModel> GetAuthors()
            => _unitOfWork.AuthorRepository.GetList().ConvertAll(AuthorMappings.MapDtoToViewModel);
    }
}
