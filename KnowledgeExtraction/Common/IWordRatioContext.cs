using Domain_models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeExtraction.Common
{
    public interface IWordRatioContext
    {
        DbSet<WordRatio> Ratios { get; set; }
    }
}