namespace KnowledgeExtraction.Preprocessing.Strategies
{
    internal interface IPdfTryExtractionStrategy<T>
    {
        public bool TryExecuteStrategy(out T result);
    }
}