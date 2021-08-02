using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CancerAM.DAL;
using CancerAM.DAL.Entities;

public class SubArticlesRepository : IRepository<SubArticle>, IDisposable
{
    private readonly CancerAmContext _context;
    private bool disposed = false;

    public SubArticlesRepository(CancerAmContext context)
    {
        _context = context;
    }

    public SubArticle Get(int id) => _context.SubArticles.FirstOrDefault(_ => _.Id == id);

    public List<SubArticle> GetList(int articleId) => _context.SubArticles.Where(_ => _.ArticleId == articleId).ToList();

    public SubArticle Insert(SubArticle entity)
    {
        if (entity != null)
        {
            var newId = _context.SubArticles.OrderByDescending(_ => _.Id).FirstOrDefault().Id + 1;
            entity.Id = newId;
            _context.SubArticles.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        return null;
    }

    public void Delete(int id)
    {
        var record = _context.SubArticles.First(_ => _.Id == id);
        _context.SubArticles.Remove(record);
        _context.SaveChanges();
    }

    public void Update(SubArticle entity)
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