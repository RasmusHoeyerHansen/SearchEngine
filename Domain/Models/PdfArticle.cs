
using System.Collections.Generic;

namespace Domain_models.Models
{
    public class PdfArticle : IMediaItem
    {
        public PdfArticle(IEnumerable<string> parsedStrings, string path, string title)
        {
            ParsedStrings = parsedStrings;
            Path = path;
            Title = title;
        }
        
        public string Path { get; set; }

        public string Title { get; set; }
        public IEnumerable<string> ParsedStrings { get; set; }
    }
}