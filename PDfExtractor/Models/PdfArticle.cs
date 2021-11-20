using System.Collections.Generic;
using PdfExtractor;

namespace PDfExtractor.Models
{
    public class PdfArticle : IStringContainer, IExtractResult
    {
        public PdfArticle(IEnumerable<string> parsedStrings)
        {
            ParsedStrings = parsedStrings;
        }

        public PdfArticle(PdfDocument document)
        {
            var path = document.Path;
        }
        public string Title { get; set; }
        

        public IEnumerable<string> ParsedStrings { get; set; }
    }
}