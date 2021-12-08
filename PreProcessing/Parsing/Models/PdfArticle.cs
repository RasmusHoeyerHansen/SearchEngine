using PreProcessingTest.Common;

namespace PreProcessingTest.Parsing.Models
{
    internal class PdfArticle : ITextItem
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