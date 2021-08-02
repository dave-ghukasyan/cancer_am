using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CancerAmContext _context;
        private bool disposed = false;

        private ArticleRepository articleRepository;
        private SubArticlesRepository subArticlesRepository;
        private CategoryRepository categoryRepository;
        private AuthorRepository authorRepository;

        public UnitOfWork(CancerAmContext context)
        {
            _context = context;
        }

        public ArticleRepository ArticleRepository
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new ArticleRepository(_context);
                }
                return articleRepository;
            }
        }

        public SubArticlesRepository SubArticlesRepository
        {
            get
            {
                if (subArticlesRepository == null)
                {
                    subArticlesRepository = new SubArticlesRepository(_context);
                }
                return subArticlesRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(_context);
                }
                return categoryRepository;
            }
        }

        public AuthorRepository AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new AuthorRepository(_context);
                }
                return authorRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();

                articleRepository?.Dispose();
                categoryRepository?.Dispose();
                authorRepository?.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
