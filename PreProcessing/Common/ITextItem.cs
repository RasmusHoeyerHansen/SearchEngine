namespace PreProcessing.Common
{
    public interface ITextItem
    {
        public string Title { get; }
        public string[] ParsedStrings { get; set; }
    }
}