using System.Collections.Generic;
using KnowledgeExtraction.Common.Models;

namespace KnowledgeExtraction.WordCounting
{
    public interface IMediaItemProcessingStrategy<out T>
    {
        public IEnumerable<T> ProcessMedia(ITextMediaItem item);
        
    }
}