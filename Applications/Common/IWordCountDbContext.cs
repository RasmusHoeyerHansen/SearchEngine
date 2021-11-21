using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Applications.Common
{
    public interface IWordCountDbContext
    {
        DbSet<PdfArticle> Articles { get; set; }
    }
}