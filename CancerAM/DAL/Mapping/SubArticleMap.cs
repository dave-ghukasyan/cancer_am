using CancerAM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CancerAM.DAL.Mapping
{
    public partial class SubArticleMap
        : IEntityTypeConfiguration<SubArticle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SubArticle> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("sub_article", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("integer");

            builder.Property(t => t.ArticleId)
                .IsRequired()
                .HasColumnName("article_id")
                .HasColumnType("integer");

            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("character varying");

            builder.Property(t => t.Body)
                .HasColumnName("body")
                .HasColumnType("text");
            
            builder.Property(t => t.Position)
                .HasColumnName("position")
                .HasColumnType("integer");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "sub_article";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string ArticleId = "article_id";
            public const string Title = "title";
            public const string Body = "body";
        }
        #endregion
    }
}
