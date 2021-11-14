using System;
using System.Collections;
using System.Collections.Generic;

namespace PDfExtractor
{
    public interface IStringContainer
    {
        public IEnumerable<string> ParsedStrings { get;}
    }
}