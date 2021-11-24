using Domain_models.Entities;
using Domain_models.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeExtraction.Common
{
    public interface IWordRatioContext
    {
        DbSet<WordRatio> Ratios { get; set; }
    }

    public interface IWordCountContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
    }
}