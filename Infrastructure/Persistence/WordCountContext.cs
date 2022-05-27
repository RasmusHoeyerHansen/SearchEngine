using System.Reflection;
using Domain_models.Entities;
using KnowledgeExtraction.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    internal class WordCountContext : DbContext, IWordRatioContext, IWordCountContext
    {
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<OccursIn> Occurrences => Set<OccursIn>();
        public DbSet<WordRatio> Ratios => Set<WordRatio>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Keys
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}