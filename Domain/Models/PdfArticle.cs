
using System.Collections.Generic;

namespace Domain_models.Models
{
    public class PdfArticle : IMediaItem
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

    public interface IMediaItem
    {
        public string Title { get;}
        public IEnumerable<string> ParsedStrings { get; set; }
    }
}