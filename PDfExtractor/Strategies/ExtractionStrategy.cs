using iTextSharp.text.pdf;

namespace PDfExtractor.Strategies
{
    public abstract class ExtractionStrategy<T> : IPdfExtractionStrategy
    {
        protected T DataItem;
        public ExtractionStrategy(T data)
        {
            DataItem = data;
        }

        public abstract string ExecuteStrategy();
    }
}