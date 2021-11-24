using Domain_models.Entities;
using Domain_models.Models;
using KnowledgeExtraction.Common;
using Microsoft.EntityFrameworkCore;

namespace DataAndInfrastructure.Persistence
{
    public class WordCountContext : DbContext, IWordRatioContext, IWordCountContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<WordRatio> Ratios { get; set; }
    }
}