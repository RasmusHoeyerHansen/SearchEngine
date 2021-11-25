using Domain_models.Entities;
using KnowledgeExtraction.Common;
using Microsoft.EntityFrameworkCore;

namespace DataAndInfrastructure.Persistence
{
    public class WordCountContext : DbContext, IWordRatioContext, IWordCountContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<WordRatio> Ratios { get; set; }
        public DbSet<WordOccurance> WordOccurances { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Word>().HasKey(a => a.Literal);
            modelBuilder.Entity<WordOccurance>().HasKey(w => new {w.ArticleId, w.Word});
            
            modelBuilder.Entity<Article>().HasOne(p => p.Author).WithMany(a => a.WrittenArticles);
            modelBuilder.Entity<WordOccurance>().HasOne(w => w.Article).WithMany(a => a.WordOccurances)
                .HasForeignKey(w => w.ArticleId);
            modelBuilder.Entity<WordOccurance>().HasOne(a => a.Word);
           

        }
    }
}