namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public abstract class  TryExtractionStrategy<T> : ExtractionStrategy<T>, IPdfTryExtractionStrategy
    {

        protected TryExtractionStrategy(T data) : base(data)
        {
           
        }
        public virtual bool TryExecuteStrategy(out string result)
        {

            try
            {
                result = ExecuteExtraction();
                return true;
            }
            catch
            {
                // ignored
                result = null;
                return false;
            }
        }
    }
}