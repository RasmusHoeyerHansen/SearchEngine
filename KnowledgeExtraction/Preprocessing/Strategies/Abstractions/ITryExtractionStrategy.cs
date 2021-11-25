namespace KnowledgeExtraction.Preprocessing.Strategies.Abstractions
{
    public interface ITryExtractionStrategy<TIn, TOut> : IExtractionStrategy<TIn, TOut>
    {
        public bool TryExtract(TIn input, TOut? result);
    }
}