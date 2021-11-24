namespace KnowledgeExtraction.Preprocessing.Strategies
{
    internal interface ITryExtractionStrategy<T>
    {
        public bool TryExecuteStrategy(out T result);
    }
}