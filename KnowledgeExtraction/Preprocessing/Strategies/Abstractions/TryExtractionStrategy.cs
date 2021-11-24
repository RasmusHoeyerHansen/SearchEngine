using System;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public abstract class  TryExtractionStrategy<T, TOut> 
        : ExtractionStrategy<T, TOut>
    {

        protected TryExtractionStrategy(T data) : base(data)
        {
           
        }
        public virtual bool TryExtract(out TOut? result)
        {

            try
            {
                result = ExecuteExtraction();
                return true;
            }
            catch
            {
                // ignored
                result = default;
                return false;
            }
        }
    }
}