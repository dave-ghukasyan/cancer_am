using CancerAM.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CancerAM.DAL.Mapping
{
    public partial class AuthorMap
        : IEntityTypeConfiguration<Author>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Author> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("author", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("integer");

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasColumnType("character varying(150)")
                .HasMaxLength(150);

            builder.Property(t => t.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.IsSuperuser)
                .IsRequired()
                .HasColumnName("is_superuser")
                .HasColumnType("boolean");

            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("is_active")
                .HasColumnType("boolean");

            builder.Property(t => t.UserName)
                .IsRequired()
                .HasColumnName("username")
                .HasColumnType("character varying(100)");

            // relationships

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "author";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string FirstName = "first_name";
            public const string LastName = "last_name";
            public const string Password = "password";
            public const string IsSuperuser = "is_superuser";
            public const string IsActive = "is_active";
        }
        #endregion
    }
}
