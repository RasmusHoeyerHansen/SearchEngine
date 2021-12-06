using Domain_models.Entities;
using KnowledgeExtraction.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAndInfrastructure.DataAccess.Configurations
{
    public class ArticleConfiguration
    {
        public ArticleConfiguration(EntityTypeBuilder<Article> builder)
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

    public class AuthorConfiguration
    {
        public AuthorConfiguration(EntityTypeBuilder<Author> builder)
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

    public class OccursInConfiguration
    {
        public OccursInConfiguration(EntityTypeBuilder<OccursIn> builder)
        {
            builder.HasKey(o => new{o.Word, o.ArticleId});    
            builder
                .HasOne<Article>(o => o.Article)
                .WithMany(a => a.Words);
            builder.HasOne<Word>(o => o.Word);
        }
        
    }
    
    public class WordConfiguration
    {
        public WordConfiguration(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();
        }
        
    }
}