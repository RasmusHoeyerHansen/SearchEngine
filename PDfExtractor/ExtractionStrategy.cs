namespace PdfExtractor
{
    public abstract class ExtractionStrategy<T> : IPdfExtractionStrategy
    {
        public T dataItem;
        public ExtractionStrategy(T data)
        {
            dataItem = data;
        }

        public abstract string ExtractText();

    }
}