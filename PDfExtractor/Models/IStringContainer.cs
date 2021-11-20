using System;
using System.Collections;
using System.Collections.Generic;

namespace PdfExtractor
{
    public interface IStringContainer
    {
        public IEnumerable<string> ParsedStrings { get;}
    }
}