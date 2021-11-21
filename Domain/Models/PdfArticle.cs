
using System.Collections.Generic;

namespace Domain.Models
{
    public class PdfArticle
    {
        public PdfArticle(IEnumerable<string> parsedStrings, string path):this(path)
        {
            ParsedStrings = parsedStrings;
        }

        public PdfArticle(string path)
        {
            this.Path = path;
        }

        public string Path { get; set; }

        public string Title { get; set; }
        

        public IEnumerable<string> ParsedStrings { get; set; }
    }
}