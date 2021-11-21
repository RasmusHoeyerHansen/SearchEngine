
using Domain.Models;

namespace PdfExtractor
{
    public interface IPdfTryFactory<in TIn> : IPdfFactory<TIn>, ITryExtractor<TIn, PdfArticle>
    {
    }
}