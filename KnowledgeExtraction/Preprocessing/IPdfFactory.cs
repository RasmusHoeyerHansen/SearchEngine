using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.Preprocessing
{
    public interface IPdfFactory<in TIn> : IExtractor<TIn, PdfArticle>
    {
    }
}