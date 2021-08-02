using CancerAM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CancerAM.DAL.Mapping
{
    public partial class ArticleMap
        : IEntityTypeConfiguration<Article>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Article> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("article", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("integer");

            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("character varying");

            builder.Property(t => t.Body)
                .HasColumnName("body")
                .HasColumnType("text");

            builder.Property(t => t.CategoryId)
                .IsRequired()
                .HasColumnName("category_id")
                .HasColumnType("integer");

            builder.Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("created_date")
                .HasColumnType("date");

            builder.Property(t => t.ModifiedDate)
                .HasColumnName("modified_date")
                .HasColumnType("date");

            builder.Property(t => t.AuthorId)
                .IsRequired()
                .HasColumnName("author_id")
                .HasColumnType("integer");

            builder.Property(t => t.ImgPath)
                .HasColumnName("img")
                .HasColumnType("text");

            builder.Property(t => t.SecondTitle)
                .HasColumnName("second_title")
                .HasColumnType("character varying(150)");

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
            public const string Name = "article";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Title = "title";
            public const string Body = "body";
            public const string CategoryId = "category_id";
            public const string CreatedDate = "created_date";
            public const string ModifiedDate = "modified_date";
            public const string AuthorId = "author_id";
            public const string ImgPath = "img_path";
            public const string SecondTitle = "second_title";
        }
        #endregion
    }
}
