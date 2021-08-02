using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.DAL
{
    public class ArticleRepository : IRepository<Article>, IDisposable
    {
        private readonly CancerAmContext _context;
        private bool disposed = false;

        public ArticleRepository(CancerAmContext context)
        {
            _context = context;
        }

        public Article Get(int id) => _context.Articles.FirstOrDefault(_ => _.Id == id);

        public List<Article> GetList(int categoryId) => _context.Articles.Where(_ => _.CategoryId == categoryId).ToList();

        public Article Insert(Article entity)
        {
            if (entity == null) return null;
            
            var newId = _context.Articles.OrderByDescending(_ => _.Id).FirstOrDefault().Id + 1;
            entity.Id = newId;
            _context.Articles.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(Article entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var record = _context.Articles.First(_ => _.Id == id);
            _context.Articles.Remove(record);
            _context.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
