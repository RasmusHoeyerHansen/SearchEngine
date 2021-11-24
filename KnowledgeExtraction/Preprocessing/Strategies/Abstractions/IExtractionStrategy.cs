using System;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public interface IExtractionStrategy<T>
    {
        public T ExecuteExtraction();
    }

}