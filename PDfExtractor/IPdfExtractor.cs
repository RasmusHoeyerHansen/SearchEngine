using PDfExtractor.Models;

namespace PdfExtractor
{
    public interface IPdfExtractor<in TIn> : IExtractor<TIn, PdfArticle>
    {
    }
}