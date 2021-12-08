using System.IO;
using PreProcessingTest.Common;
using PreProcessingTest.Common.Exceptions;
using PreProcessingTest.Parsing.Models;
using PreProcessingTest.Parsing.Parsers.Strategies;
using PreProcessingTest.Parsing.Parsers.Strategies.Abstractions;
using PdfDocument = PreProcessingTest.Parsing.Models.PdfDocument;

namespace PreProcessingTest.Parsing.Parsers
{
    internal partial class TextItemFactory : ITextItemFactory<Models.PdfDocument>, ITextItemFactory<Stream>
    {
        public ITextItem? Extract(Models.PdfDocument document)
        {
            var res = Parse(document, new PdfExtractionStrategy());
            return res ?? throw new PdfParsingException();
        }

        private PdfArticle? Parse(Models.PdfDocument document, IExtractionStrategy<Models.PdfDocument, PdfArticle> strategy)
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