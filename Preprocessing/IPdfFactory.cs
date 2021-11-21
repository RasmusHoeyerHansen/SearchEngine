
using Domain.Models;

namespace PdfExtractor
{
    public interface IPdfFactory<in TIn> : IExtractor<TIn, PdfArticle>
    {
    }
}