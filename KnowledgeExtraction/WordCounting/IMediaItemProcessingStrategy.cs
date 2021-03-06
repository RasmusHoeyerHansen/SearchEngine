using System.Collections.Generic;
using Domain_models.Entities;
using KnowledgeExtraction.Common;
using PreProcessing.Common;

namespace KnowledgeExtraction.WordCounting
{
    public interface IMediaItemProcessingStrategy<out T>
    {
        public IEnumerable<T> ProcessMedia(ITextItem item);
    }
}