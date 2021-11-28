namespace KnowledgeExtraction.Common.Models
{
    public interface ITextMediaItem
    {
        public string Title { get;}
        public string[] ParsedStrings { get; set; }
    }
}