namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public abstract class ExtractionStrategy<T> : IPdfExtractionStrategy
    {
        protected T DataItem;
        public ExtractionStrategy(T data)
        {
            DataItem = data;
        }

        public abstract string ExecuteExtraction();
    }
}