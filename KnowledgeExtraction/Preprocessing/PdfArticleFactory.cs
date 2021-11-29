using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Strategies;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing
{
    internal class PdfArticleFactory : IPdfFactory<Models.PdfDocument>
    {
        public PdfArticle? Extract(PdfDocument document)
        {
            return Parse(document,new PdfExtractionStrategy());
        }

        private PdfArticle? Parse(PdfDocument document, IExtractionStrategy<PdfDocument, PdfArticle> strategy)
        {
            return strategy.ExecuteExtraction(document);
        }

        public PdfArticle? Parse(string path)
        {
            return new PdfExtractionStrategy().ExecuteExtraction(path);
        }
    }

}