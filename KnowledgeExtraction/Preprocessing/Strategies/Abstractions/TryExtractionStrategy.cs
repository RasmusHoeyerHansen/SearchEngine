using System;

namespace KnowledgeExtraction.Preprocessing.Strategies.Abstractions
{
    public abstract class  TryExtractionStrategy<T, TOut> 
        : Preprocessing.ITryExtractionStrategy<T, TOut>
    {
        public abstract TOut? ExecuteExtraction(T data);

        public bool TryExtract(T input, TOut? result)
        {
            try
            {
                result = ExecuteExtraction(input);
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