using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CancerAM.DAL.Entities;

namespace CancerAM.DAL
{
    public class AuthorRepository : IRepository<Author>, IDisposable
    {
        private readonly CancerAmContext _context;
        private bool disposed = false;

        public AuthorRepository(CancerAmContext context)
        {
            _context = context;
        }

        public Author Get(int id) => _context.Authors.FirstOrDefault(_ => _.Id == id);

        public List<Author> GetList() => _context.Authors.ToList();

        public void Delete(int id)
        {
            var record = _context.Authors.First(_ => _.Id == id);
            _context.Authors.Remove(record);
            _context.SaveChanges();
        }
        
        public Author Insert(Author entity)
        {
            if (entity != null)
            {
                _context.Authors.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public void Update(Author entity)
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

