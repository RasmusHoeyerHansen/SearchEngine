namespace KnowledgeExtraction.Common.Models
{
    public class PdfArticle : ITextMediaItem
    {
        public PdfArticle(string[] parsedStrings, string title)
        {
            ParsedStrings = parsedStrings;
            Title = title;
        }
        

        public string Title { get; }
        public string[] ParsedStrings { get; set; }
    }
}