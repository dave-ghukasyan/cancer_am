using CancerAM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CancerAM.DAL.Mapping
{
    public partial class CategoryMap
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("category", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("integer");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("character varying(150)")
                .HasMaxLength(150);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "category";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Name = "name";
        }
        #endregion
    }
}
