using Domain_models.Entities;
using KnowledgeExtraction.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.DataAccess.Configurations
{
    public class ArticleConfiguration: IEntityTypeConfiguration<Article>
    {

        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.HasOne(article => article.Author)
                .WithMany(author => author.WrittenArticles)
                .HasForeignKey(a => a.AuthorName);

            builder.
                HasMany<OccursIn>(a => a.Words)
                .WithOne(a => a.Article);
            
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();
        }
    }
}