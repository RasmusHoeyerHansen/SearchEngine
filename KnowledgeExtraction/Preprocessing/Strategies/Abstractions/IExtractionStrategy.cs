namespace KnowledgeExtraction.Preprocessing.Strategies.Abstractions
{
    public interface IExtractionStrategy<TIn, TOut>
    {
        public TOut? ExecuteExtraction(TIn data);
    }

}