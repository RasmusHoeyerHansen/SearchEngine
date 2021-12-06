using Domain_models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorName);
            builder.Property(a => a.AuthorName)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany<Article>(author => author.WrittenArticles)
                .WithOne(article => article.Author)
                .HasForeignKey(a => a.AuthorName);
        }
    }
}