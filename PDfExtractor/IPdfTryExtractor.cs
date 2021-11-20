using PDfExtractor.Models;

namespace PdfExtractor
{
    public interface IPdfTryExtractor<in TIn> : IPdfExtractor<TIn>, ITryExtractor<TIn, PdfArticle>
    {
    }
}