using System;
using System.Collections;
using System.Collections.Generic;

namespace PDfExtractor
{
    public class PdfExtractResult : IStringContainer
    {
        public PdfExtractResult(IEnumerable<string> parsedStrings)
        {
            ParsedStrings = parsedStrings;
        }

        public IEnumerable<string> ParsedStrings { get; set; }
    }
}