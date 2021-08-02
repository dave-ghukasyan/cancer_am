using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.DAL
{
    public class CategoryRepository : IRepository<Category>, IDisposable
    {
        private readonly CancerAmContext _context;
        private bool disposed = false;

        public CategoryRepository(CancerAmContext context)
        {
            _context = context;
        }

        public Category Get(int id) => _context.Categories.FirstOrDefault(_ => _.Id == id);

        public List<Category> GetList() => _context.Categories.ToList();

        public void Delete(int id)
        {
            var record = _context.Categories.First(_ => _.Id == id);
            _context.Categories.Remove(record);
            _context.SaveChanges();
        }
        
        public Category Insert(Category entity)
        {
            if (entity != null)
            {
                _context.Categories.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public void Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
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
