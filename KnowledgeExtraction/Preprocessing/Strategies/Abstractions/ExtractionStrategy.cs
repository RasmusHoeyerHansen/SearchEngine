namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public abstract class ExtractionStrategy<T, TOut> : IExtractionStrategy<TOut>
    {
        protected T DataItem;

        public ExtractionStrategy(T data)
        {
            DataItem = data;
        }

        public abstract TOut ExecuteExtraction();
        protected abstract string ReadText();
    }
}