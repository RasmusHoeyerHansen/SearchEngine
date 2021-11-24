namespace KnowledgeExtraction.Preprocessing.Strategies
{
    internal interface IPdfTryExtractionStrategy
    {
        public bool TryExecuteStrategy(out string result);
    }
}