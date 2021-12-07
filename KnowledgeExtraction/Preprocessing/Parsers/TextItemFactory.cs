using System.IO;
using KnowledgeExtraction.Common;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies;
using KnowledgeExtraction.Preprocessing.Parsers.Strategies.Abstractions;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace KnowledgeExtraction.Preprocessing.Parsers
{
    internal partial class TextItemFactory : ITextItemFactory<PdfDocument>, ITextItemFactory<Stream>
    {
        public ITextItem? Extract(PdfDocument document)
        {
            var res = Parse(document, new PdfExtractionStrategy());
            return res ?? throw new PdfParsingException();
        }

        private PdfArticle? Parse(PdfDocument document, IExtractionStrategy<PdfDocument, PdfArticle> strategy)
        {
            var res = strategy.ExecuteExtraction(document);
            return res ?? throw new PdfParsingException();
        }

        public ITextItem? Parse(string path)
        {
            var res = new PdfExtractionStrategy().ExecuteExtraction(path);
            return res ?? throw new PdfParsingException();
        }

        public ITextItem? Extract(Stream inputElement)
        {
            var res = new StreamExtractionStrategy().ExecuteExtraction(inputElement);
            return res ?? throw new PdfParsingException();
        }
    }
}