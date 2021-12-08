using System.IO;
using PreProcessing.Common;
using PreProcessing.Common.Exceptions;
using PreProcessing.Parsing.Models;
using PreProcessing.Parsing.Parsers.Strategies;
using PreProcessing.Parsing.Parsers.Strategies.Abstractions;

namespace PreProcessing.Parsing.Parsers
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