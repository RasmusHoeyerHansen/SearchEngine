using KnowledgeExtraction.Common.Models;

namespace KnowledgeExtraction.Models
{
    public class PdfArticle : ITextMediaItem
    {
        public PdfArticle(string[] parsedStrings, string path, string title)
        {
            ParsedStrings = parsedStrings;
            Path = path;
            Title = title;
        }

        public string Path { get; }

        public string Title { get; }
        public string[] ParsedStrings { get; set; }
    }
}