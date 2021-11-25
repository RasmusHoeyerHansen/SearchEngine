namespace KnowledgeExtraction.Models
{
    internal interface ITextMediaItem
    {
        public string Title { get;}
        public string[] ParsedStrings { get; set; }
    }
}