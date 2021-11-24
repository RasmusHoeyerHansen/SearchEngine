
using Domain_models.Models;

namespace KnowledgeExtraction.Preprocessing
{
    public interface IPdfTryFactory<in TIn> : IPdfFactory<TIn>, ITryExtractor<TIn, PdfArticle>
    {
    }
}