namespace PDfExtractor.Strategies
{
    internal interface IPdfTryExtractionStrategy
    {
        public bool TryExecuteStrategy(out string result);
    }
}