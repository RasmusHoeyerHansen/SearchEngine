namespace KnowledgeExtraction.Preprocessing.Strategies.Abstractions
{
    internal interface IExtractionStrategy<TIn, TOut>
    {
        public TOut? ExecuteExtraction(TIn data);
    }

}