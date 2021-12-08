namespace PreProcessingTest.Parsing.Parsers.Strategies.Abstractions
{
    internal interface IExtractionStrategy<TIn, TOut>
    {
        public TOut? ExecuteExtraction(TIn data);
    }
}