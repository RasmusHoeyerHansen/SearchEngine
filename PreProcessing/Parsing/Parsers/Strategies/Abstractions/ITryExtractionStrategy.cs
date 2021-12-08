namespace PreProcessing.Parsing.Parsers.Strategies.Abstractions
{
    internal interface ITryExtractionStrategy<TIn, TOut> : IExtractionStrategy<TIn, TOut>
    {
        public bool TryExtract(TIn documentStream, out TOut result);
    }
}