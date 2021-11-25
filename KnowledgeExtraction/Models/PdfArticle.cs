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
        public PdfArticle( string path, string title, params string[] parsedStrings)
        {
            ParsedStrings = parsedStrings;
            Path = path;
            Title = title;
        }
        
        public string Path { get; set; }

        public string Title { get; set; }
        public string[] ParsedStrings { get; set; }
    }
}