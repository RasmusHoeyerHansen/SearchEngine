using Domain_models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeExtraction.Common
{
    public interface IWordCountContext
    {
        public DbSet<OccursIn> Occurances { get; }
        DbSet<Article> Articles { get; }
        DbSet<Author> Authors { get; }
    }
}