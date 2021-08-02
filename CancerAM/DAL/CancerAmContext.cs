using CancerAM.DAL.Entities;
using CancerAM.DAL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CancerAM.DAL
{
    public partial class CancerAmContext : DbContext
    {
        public CancerAmContext(DbContextOptions<CancerAmContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<SubArticle> SubArticles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SubArticleMap());
            #endregion
        }
    }
}
