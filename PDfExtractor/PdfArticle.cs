using System;
using System.Collections;
using System.Collections.Generic;

namespace PdfExtractor
{
    public class PdfArticle : IStringContainer
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