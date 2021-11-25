using Domain_models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeExtraction.Common
{
    public interface IWordCountContext
    {
        public DbSet<WordOccurance> WordOccurances { get; set; }

        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
    }
}