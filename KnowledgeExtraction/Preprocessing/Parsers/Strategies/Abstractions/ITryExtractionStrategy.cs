namespace KnowledgeExtraction.Preprocessing.Parsers.Strategies.Abstractions
{
    internal interface ITryExtractionStrategy<TIn, TOut> : IExtractionStrategy<TIn, TOut>
    {
        public bool TryExtract(TIn inputDocument, out TOut result);
    }
}