using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.DAL
{
    public interface IUnitOfWork
    {
        #region Repositories
        ArticleRepository ArticleRepository { get; }
        SubArticlesRepository SubArticlesRepository { get; }
        CategoryRepository CategoryRepository { get; }
        AuthorRepository AuthorRepository { get; }
        #endregion  

        void Save();
    }
}
