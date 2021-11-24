using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;

namespace KnowledgeExtraction.Preprocessing
{
    public interface ITryExtractionStrategy<TIn, TOut> : IExtractionStrategy<TIn, TOut>
    {
        public bool TryExtract(TIn input, TOut? result);
    }
}