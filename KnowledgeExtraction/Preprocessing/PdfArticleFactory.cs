using System;
using Domain_models.Models;
using iTextSharp.text;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Strategies;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing
{
    public class PdfArticleFactory : IPdfFactory<ByteDocument>, IPdfFactory<Models.PdfDocument> 
    {
        public PdfArticle? Parse(PdfDocument document)
        {
            return Parse(document,new PdfExtractionStrategy());
        }

        private PdfArticle? Parse(PdfDocument document, PdfExtractionStrategy strategy)
        {
            return strategy.ExecuteExtraction(document);
        }

        public PdfArticle? Parse(PdfDocument document, IExtractionStrategy<PdfDocument, PdfArticle?> strategy)
        {
            return strategy.ExecuteExtraction(document);
        }

        public PdfArticle? Parse(ByteDocument document)
        {
            return Parse(document, new ByteArrayExtractionStrategy());
        }

        private PdfArticle? Parse(ByteDocument document, ByteArrayExtractionStrategy strategy)
        {
            return strategy.ExecuteExtraction(document.Bytes);
        }

    }
}