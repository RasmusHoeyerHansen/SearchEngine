using System;
using Domain_models.Models;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Strategies;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing
{
    public class PdfArticleFactory : IPdfFactory<ByteDocument>, IPdfFactory<Models.PdfDocument> 
    {
        public PdfArticle Parse(PdfDocument document)
        {
            return Parse(document,new PdfExtractionStrategy(document, document.Path) );
        }

        public PdfArticle Parse(PdfDocument document, IExtractionStrategy<PdfArticle> strategy)
        {
            return strategy.ExecuteExtraction();
        }

        public PdfArticle Parse(ByteDocument document)
        {
            return Parse(document, new ByteArrayExtractionStrategy(document));
        }
        
        public PdfArticle Parse(ByteDocument document, IExtractionStrategy<PdfArticle> strategy)
        {
            return strategy.ExecuteExtraction();
        }
    }
}