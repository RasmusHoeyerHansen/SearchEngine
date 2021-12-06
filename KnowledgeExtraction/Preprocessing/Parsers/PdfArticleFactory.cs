using System.IO;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies.Abstractions;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing.Parsers
{
    internal class PdfArticleFactory : IPdfFactory<Models.PdfDocument>, IPdfFactory<Stream>
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

        public PdfArticle? Extract(Stream inputElement)
        {
            return new StreamExtractionStrategy().ExecuteExtraction(inputElement);
        }
    }

}